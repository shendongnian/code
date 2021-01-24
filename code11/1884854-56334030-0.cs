    [Route("test/{*url}")]
    public class TestController : Controller
    {
        // so that all request that start with 'test' go through this method
        public IActionResult Process()
        {
            return new JsonResult(new{
                a = 1,
            });
        }
    }
