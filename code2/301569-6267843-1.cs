    public class BaseController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            // retireve data
            var data = new ApplicationBaseModel();
            // set to viewbag
            ViewBag.UserData = data;
        }
    }
