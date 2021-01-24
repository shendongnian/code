    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ILGAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ILGAuthorizeScheme _AuthenticationScheme;
        public ILGAuthorizeAttribute(ILGAuthorizeScheme AuthenticationScheme)
        {
            _AuthenticationScheme = AuthenticationScheme;
        }
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                var actionAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true);
                if (actionAttributes.Any(x => x is AllowAnonymousAttribute))
                    return;
            }            
            if (filterContext != null)
            {
                string url = filterContext.HttpContext.Request.Path;
                if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    if (url.ToLower().StartsWith("/admin") && _AuthenticationScheme.ToString().ToLower() == "admin")
                    {
                        var authenticateAdminResult = filterContext.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "UserId" && claim.Issuer.Equals("Admin", StringComparison.InvariantCultureIgnoreCase));
                        if (authenticateAdminResult == null)
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "", controller = "Home", action = "Index" }));
                    }
                    else
                    {
                        var authenticateSubscriberResult = filterContext.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "SubscriberId" && claim.Issuer.Equals("Subscriber", StringComparison.InvariantCultureIgnoreCase));
                        if (authenticateSubscriberResult == null)
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "Admin", controller = "Home", action = "Index" }));
                    }
                }
                else
                {
                    if (url.ToLower().StartsWith("/admin"))
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "Admin", controller = "Account", action = "Login" }));
                    else
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "", controller = "Account", action = "CreateUsernamePassword" }));
                }
            }
        }
    }
