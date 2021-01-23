    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary 
                                   {
                                       { "action", "ActionName" },
                                       { "controller", "ControllerName" }
                                   });
            }
            else
                base.HandleUnauthorizedRequest(filterContext);
        }
    }
