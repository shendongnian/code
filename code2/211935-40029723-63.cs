    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [MyAttribute("SomeArgument")]
    public class ValuesController : Controller
    {
        [HttpGet]
        [MyAttribute("AnotherArgument")]
        public string Get()
        {
            return "Foobar";
        }
    }
