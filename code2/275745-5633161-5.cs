    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthenticated = base.AuthorizeCore(httpContext);
            if (isAuthenticated) 
            {
                string cookieName = FormsAuthentication.FormsCookieName;
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated ||
                    filterContext.HttpContext.Request.Cookies == null || 
                    filterContext.HttpContext.Request.Cookies[cookieName] == null)
                {
                    return false;
                }
                var authCookie = filterContext.HttpContext.Request.Cookies[cookieName];
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
       
                // This is where you can read the userData part of the authentication
                // cookie and fetch the token
                string webServiceToken = authTicket.UserData;
                IPrincipal userPrincipal = ... create some custom implementation
                                               and store the web service token as property
                // Inject the custom principal in the httpcontext
                filterContext.HttpContext.User = userPrincipal;
            }
            return isAuthenticated;
        }
    }
