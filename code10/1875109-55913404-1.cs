        public class HomeController : Controller
        {
            private readonly ApplicationDbContext _appDbContext;
            public HomeController(ApplicationDbContext applicationDbContext)
            {
                _appDbContext = applicationDbContext;
            }        
            public async Task<IActionResult> Index()
            {
                var user = _appDbContext.CurrentUser;
                return View();
            }
            
        }
