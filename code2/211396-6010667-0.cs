    public class BaseController : Controller
    {
        public string ActionName;
        public string ControllerName;
    
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Switch the language in here?
           CultureInfo cultureInfo = new CultureInfo("en-US");
            this.Culture = "en-US";
            this.UICulture = "en-US";
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }
    }
