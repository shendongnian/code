    public class PersonAuthorizationController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly MainDbContext _context;
        public PersonAuthorizationController(
            MainDbContext context, 
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        // GET: Contact/PersonAuthorization
        public async Task<IActionResult> Index()
        {
            var currentUserId = _userManager.GetUserId(User);
            return View();
        }
