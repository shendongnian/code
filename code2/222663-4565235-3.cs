    public class RoleAuthorizeAttribute : AuthorizeAttribute
        {
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                // Returns HTTP 401 
                // If user is not logged in prompt
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
                // Otherwise deny access
                else
                {
                    filterContext.Result = new RedirectToRouteResult(@"Default", new RouteValueDictionary{
                    {"controller","Account"},
                    {"action","NotAuthorized"}
                    });
                }
            }
        }
