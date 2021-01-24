    public class HomeController : Controller
    {
        private readonly LinkGenerator linkGenerator;
    
        public HomeController(LinkGenerator linkGenerator)
        {
            this.linkGenerator = linkGenerator;
        }
    	
    	// ..
    }
