    [Area("Foo")]
    [Route("[controller]")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
