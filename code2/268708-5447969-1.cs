    public class IsSubscribedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity == null || 
                  !filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                 filterContext.Result = 
                  new RedirectResult(System.Web.Security.FormsAuthentication.LoginUrl
                               + "?returnUrl=" + 
                  filterContext.HttpContext.Server.UrlEncode
                               (filterContext.HttpContext.Request.RawUrl));
            }
            if (isSubscribed)//check subscription here.
            {
                filterContext.HttpContext.Response.StatusCode = 401;
                filterContext.Result = new HttpUnauthorizedResult();
            }//you can set the statuscode/result as you like?
        }
    }
