    public class BaseController : Controller
    {
        protected virtual new MyPrincipal User
        {
            get { return HttpContext.User as MyPrincipal; }
        }
    }   
