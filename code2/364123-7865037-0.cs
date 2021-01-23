    public class HomeController : Controller
    {
        private IHelloService _service;
    
        /*
              No default constructor
        */
    
        public string Index()
        {
            _service= DependencyResolver.Current.GetService<IHelloService>();
            return _service.GetGreeting();
        }
    }
