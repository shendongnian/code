    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [InversionOfControl("Foobar")]
    public class ValuesController : Controller
    {
        [HttpGet]
        [InversionOfControl("Foobar")]
        public string Get()
        {
            return "Foobar";
        }
    }
