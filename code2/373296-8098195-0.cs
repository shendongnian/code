    public class HomeController : Controller { 
        protected IMyService myService { get; set; } 
     
        public HomeController(IMyService myService) { 
            this.myService = myService; 
        } 
    } 
    public class MyService {
        protected IPrincipal principal;
        public MyService(IPrincipal principal) { this.principal = principal)
    }
