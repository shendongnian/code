    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        [Inject]
        public IService Service { get; set; }
        [Inject]
        public IAuthenticationHelper AuthenticationHelper { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
        }
    }
 
