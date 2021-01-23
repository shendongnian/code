    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
    
        }
    
        protected void PopulateViewModel()
        {
            //code to populate view model here
        }
    }
    
    public class MyController : BaseController
    {
        [HttpGet]
        public virtual ActionResult myAction()
        {
            PopulateViewModel();
            //do more stuff
        }
    }
