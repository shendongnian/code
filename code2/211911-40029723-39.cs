    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [InversionOfControl("SomeArgument")]
    public class ValuesController : Controller
    {
        [HttpGet]
        [InversionOfControl("AnotherArgument")]
        public string Get()
        {
            return "Foobar";
        }
    }
