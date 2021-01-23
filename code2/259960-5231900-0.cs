    public class HomeController : ApplicationController
    {
        public HomeController(IModuleRepository moduleRepository) : base(moduleRepository)
        {
          //other constructor code here
        }
    
        public HomeController() : this(null)
        {
          //default constructor
        }
    }
    
    public abstract class ApplicationController : Controller
    {
      public IModuleRepoistory _moduleRepository { get; private set; }
      public ApplicationController(IModuleRepository moduleRepository)
      {
        _moduleRepository = moduleRepository ?? new DefaultModuleRepository();
        //...
      }
    }
