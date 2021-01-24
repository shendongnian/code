    [Route("MyApplication")]
    public class MyController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Blah!
        }
    }
