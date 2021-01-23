    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (isAuthorized)
            {
                // The user is authorized so far => check his credentials against
                // the custom data store 
                return IsUserAllowedAccess(httpContext.User.Identity.Name);
            }
            return isAuthorized;
        }
        private bool IsUserAllowedAccess(string username)
        {
            throw new NotImplementedException();
        }
    }
