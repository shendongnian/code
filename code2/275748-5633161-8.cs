    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthenticated = base.AuthorizeCore(httpContext);
            if (isAuthenticated) 
            {
                string cookieName = FormsAuthentication.FormsCookieName;
                if (!httpContext.User.Identity.IsAuthenticated ||
                    httpContext.Request.Cookies == null || 
                    httpContext.Request.Cookies[cookieName] == null)
                {
                    return false;
                }
                var authCookie = httpContext.Request.Cookies[cookieName];
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
       
                // This is where you can read the userData part of the authentication
                // cookie and fetch the token
                string webServiceToken = authTicket.UserData;
                IPrincipal userPrincipal = ... create some custom implementation
                                               and store the web service token as property
                // Inject the custom principal in the HttpContext
                httpContext.User = userPrincipal;
            }
            return isAuthenticated;
        }
    }
