    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated ||
                filterContext.HttpContext.Request.Cookies == null || filterContext.HttpContext.Request.Cookies[cookieName] == null)
            {
                this.HandleUnauthorizedRequest(filterContext);
                return;
            }
            var authCookie = filterContext.HttpContext.Request.Cookies[cookieName];
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
       
            // This is where you can read the userData part of the authentication
            // cookie and fetch the token
            string webServiceToken = authTicket.UserData;
            IPrincipal userPrincipal = ... create some custom implementation
                                           and store the web service token as property
            filterContext.HttpContext.User = userPrincipal;
            base.OnAuthorization(filterContext);
        }
    }
