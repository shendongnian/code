    namespace WebApp
    {
        using Microsoft.AspNetCore.Mvc;
    
        [Route("api/[controller]")]
        [MyActionFilter]
        public class ValuesController : Controller
        {
            // GET api/values
            [HttpGet]
            [MyActionFilterAttribute]
            public string Get()
            {
                return "Foobar";
            }
        }
    }
