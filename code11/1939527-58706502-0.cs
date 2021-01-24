    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration = null;
        private readonly ApplicationDbContext _dbContext;
        public HomeController(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var configurationRoot = _configuration as IConfigurationRoot;
            var provider = (DbProvider)configurationRoot.Providers.Last();
            
           // Or get specific provider using index as below comment has shown
           // var list = configurationRoot.Providers.ToList();
           // var provider = (DbProvider)list[5];
            var connectionSettings = provider.connectionSettings;
                 
            return View();
        }
    }
     
       
