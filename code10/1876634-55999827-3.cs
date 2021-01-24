        [ApiController]
        public class PostController : Controller
        {
            [HttpGet("posts")]
            public IActionResult Get()
            {
                return new MyBadRequestObjectResult();
            }
            [HttpGet("posts1")]
            public IActionResult Get1()
            {
                List<String> errors = new List<String> { "Code is invalid" };
                return new MyBadRequestObjectResult(errors);
            }
        }
