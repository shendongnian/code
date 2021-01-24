    namespace APIVersions.Controllers
    {
        [ApiVersion("1.0")]
        [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            [HttpGet]
            public IActionResult Get() => Ok(new string[] { "value1" });
        }
    }
