    using Microsoft.AspNetCore.Mvc;
    using AspNetCoreFilterDemo.Filters;
    
    namespace AspNetCoreFilterDemo.Controllers
    {
        public class HomeController : Controller
        {
            public HomeController()
            {
    
            }
    
            [AuthorizationFilterWithFactory]
            public IActionResult Index()
            {
                return View();
            }
        }
    }
