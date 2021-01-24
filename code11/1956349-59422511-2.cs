    namespace APIVersions.Controllers3
    {
        [ApiVersion("2.0")]
        [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            [HttpGet]
            public IActionResult Get() => Ok(new string[] { "value1" });
        }
    }
