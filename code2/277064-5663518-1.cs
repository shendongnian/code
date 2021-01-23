    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SageAdminAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        readonly IAuthentication _authentication;
        public SageAdminAuthorizeAttribute(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!_authentication.Authorize(filterContext.HttpContext))
                throw new UnauthorizedAccessException();
        }
    }
