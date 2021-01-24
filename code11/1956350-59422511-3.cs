    namespace APIVersions.Controllers
    {
        [ApiVersion("1.0")]
        [ApiVersion("2.0")]
        [Route("api/v{version:apiVersion}/[controller]")]
        public class ValuesController : Controller
        {
            [HttpGet]
            public IActionResult Get() => Ok(new string[] { "value1" });
     
            [HttpGet, MapToApiVersion("2.0")]
            public IActionResult GetV3() => Ok(new string[] { "value3" });
        }
    }
