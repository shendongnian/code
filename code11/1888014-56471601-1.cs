        public class HomeController : Controller
        {
            private readonly IConfiguration _configuration;
            public HomeController(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public IActionResult Index()
            {
                return Ok(_configuration.GetConnectionString("DefaultConnection"));
                //return View();
            }
        }
