        [Route("api/v{version:apiVersion}/[controller]/[action]")]
        [ApiController]
        public class ValuesController : ControllerBase
        {
            [HttpGet]
            public IActionResult Hello()
            {
                return Ok("Test");
            }
        }
