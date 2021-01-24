    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public bool IsIgnore {get;set;}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (IsIgnore)
                base.OnActionExecuting(filterContext);
            HttpContext ctx = HttpContext.Current;
            // check  sessions here
            if( HttpContext.Current.Session["username"] == null ) 
            {
               filterContext.Result = new RedirectResult("~/Account/Login");
               return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
    //SAMPLE IMPLEMENTATION:
    [SessionExpire]
    public class HomeController : Controller
    {
      public ActionResult Index()
      {
       return Index();
      }
    //I WANT TO BYPASS THIS JSONRESULT WITHOUT GOING TO SESSIONEXPIRE
      [SessionExpire(IsIgnore = true)]
      public JsonResult Result()
      {
         return Json();
      }
    }
