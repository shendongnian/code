    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return Ok(configuration.GetConnectionString("DefaultConnection"));
            //return View();
        }
