    public class HomeController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            filterContext.Result = new HttpStatusCodeResult(304, "Not Modified");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
