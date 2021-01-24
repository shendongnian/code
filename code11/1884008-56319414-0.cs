    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
    
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment= webHostEnvironment;
        }
    
        public IActionResult Index()
        {
            return Content(_webHostEnvironment.WebRootPath + "\n" + _webHostEnvironment.ContentRootPath);
        }
    }
