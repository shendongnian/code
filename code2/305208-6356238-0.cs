    private static void SetRedirectToLoginPageForContext(AuthorizationContext filterContext)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                                                     {
                                                                         { "controller", "Login" },
                                                                         { "action", "Index" }
                                                                     });
            }
    public class UserAuthenticatedAction : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
                SetRedirectToLoginPageForContext(filterContext);
                return;
        }
    }
