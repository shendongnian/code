    public class StudentController : Controller
    {
        public ActionResult Index()
        {
             string name = "New Name";
             System.Web.HttpContext.Current.Session["sessionString"] = name;
        }
    }
 
