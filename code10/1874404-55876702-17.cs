    public class HomeController : Controller
    {
        private readonly IClientRepository _repository;
    
        public HomeController(IClientRepository repository)
        {
            _repository = repository;
        }
    
        public IActionResult Index()
        {
           // save the connectionString in the HttpContext.Items
           HttpContext.Items["connection-string"] = "test-connection";
   
           // set the context 
           _repository.SetContext();
    
           return View();
        }
    }
