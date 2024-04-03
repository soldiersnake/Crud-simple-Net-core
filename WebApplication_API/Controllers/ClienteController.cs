using Microsoft.AspNetCore.Mvc;
using WebApplication_API.Models;

namespace WebApplication_API.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {

            List<Cliente> Clientes = new List<Cliente> {
                new Cliente
                {
                    id = "1",
                    correo = "Google@gmail.com",
                    edad = "19",
                    nombre = "Mariano",
                },
                new Cliente
                {
                    id = "2",
                    correo = "gmail@gmail.com",
                    edad = "23",
                    nombre = "Jose",
                },
            };
            return Clientes;
        }

        [HttpGet]
        [Route("listarxID")]
        public dynamic listarClientexID(string _id, string _nombre)
        {
        //obtienes el cliente de la DB
                            
                
            return new Cliente
            {
                id = _id.ToString(),
                correo = _nombre.ToString(),
                edad = "23",
                nombre = "Jose",
            };
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = "3";
            return new
            {
                succes = true,
                message = "Cliente Registrado",
                Results = cliente,
            };
        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where( x => x.Key == "Authorization").FirstOrDefault().Value;
            if(token != "marco123.")
            {
                return new
                {
                    succes = false,
                    message = "Token incorrecto",
                    Results = "",
                };
            }
            //eliminas el cliente en DB
            cliente.id = "3";
            return new
            {
                succes = true,
                message = "Cliente Eliminado",
                Results = cliente,
            };
        }
    }
}
