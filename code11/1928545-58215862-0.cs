    public class HomeController : Controller {
        private readonly IProcessFactory factory;
        private readonly MyConfigurations _myConfigurations;
        public HomeController(IProcessFactory factory, MyConfigurations configurations) {
             this.factory = factory;
        }
        //...omitted for brevity
    }
