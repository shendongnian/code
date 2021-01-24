    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ApplicationSignInManager _applicationSignInManager;
        public HomeController(ApplicationDbContext context
            , ApplicationSignInManager applicationSignInManager)
        {
            _dbContext = context;
            _applicationSignInManager = applicationSignInManager;
        }
