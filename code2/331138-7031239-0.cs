    public class RequiresAuthenticationAttribute : ActionFilterAttribute
    {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        //You can put your check here. This particular
        //check is for default asp.net membership authentication
    
        if(!filterContext.HttpContext.User.Identity.IsAuthenticated)
        {
            RedirectToLogin(filterContext);
        }
    }
     
    private void RedirectToLogin(ActionExecutingContext filterContext)
    {
        var redirectTarget = new RouteValueDictionary
        {
            {"action", "LogOn"},
            {"controller", "Account"}
        };
    
        filterContext.Result = new RedirectToRouteResult(redirectTarget);
        }
    }
