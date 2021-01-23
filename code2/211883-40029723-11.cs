    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [MyFilter]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [MyFilter]
        public string Get()
        {
            return "Foobar";
        }
    }
