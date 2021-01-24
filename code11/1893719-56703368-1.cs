        public class HomeController : Controller {
        
           private readonly IConfiguration _config;
    
           public HomeController(IConfiguration config) { _config = config; }
        
           public IActionResult Index() {
    
              Console.WriteLine(_config.GetSection("AppSettings:Token").Value);
     
              return View();
        
               }
       }
