    public class CustomAuthorizer : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool isAuthorized = IsAuthorized(filterContext); // check authorization
            base.OnAuthorization(filterContext);
            if (!isAuthorized && !filterContext.ActionDescriptor.ActionName.Equals("Unauthorized", StringComparison.InvariantCultureIgnoreCase)
                && !filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.Equals("LogOn", StringComparison.InvariantCultureIgnoreCase))
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result =
           new RedirectToRouteResult(
               new RouteValueDictionary{{ "controller", "LogOn" },
                                              { "action", "Unauthorized" }
                                             });
        }
    }
