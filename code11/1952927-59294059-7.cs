    using Microsoft.AspNetCore.Mvc;
    
    namespace WebApiTest.Controllers
    {
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class ResourceController : ControllerBase
        {
            [HttpGet]
            //api/Resource/GetAll
            public IActionResult GetAll()
            {
                return Content("I got nth");
            }
            //GET: //api/Resource/GetAll/2
            [HttpGet("{parameter}")]
            public IActionResult GetAll(int parameter)
            {
                return Ok($"Parameter {parameter}");
            }
        }
    }
