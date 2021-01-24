    [Area("Area1")]
    [Route("Area1/[controller]/[action]")]
    public class Area1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
