        public class HomeController : Controller
        {       
            private readonly ApplicationDbContext _context;       
            public HomeController(ApplicationDbContext context)
            {
                _mapper = mapper;
                _context = context;
                _userManager = userManager;
                _userStore = userStore;
            }
            public async Task<IActionResult> Index()
            {
                var existingStudent = _context.Result.ToList();           
                return View();
            }        
        }
