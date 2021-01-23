    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SageAdminAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        readonly IAuthentication _authentication;
        public SageAdminAuthorizeAttribute(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!_authentication.Authorize(filterContext.HttpContext))
                filterContext.Result = new HttpUnauthorizedResult();
        }
    }
