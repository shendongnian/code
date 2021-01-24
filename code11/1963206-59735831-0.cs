    public class HomeController : Controller
        {
            private readonly IConfiguration configuration;
    
            public HomeController(IConfiguration config)
            {
                this.configuration = config;
            }
    
            public IActionResult Index()
            {
                string connectionstring = configuration.GetConnectionString("DefaultConnection");
                SqlConnection sqlconnection = new SqlConnection(connectionstring);
                sqlconnection.Open();
                
    
                sqlconnection.Close();
                return View();
            }
