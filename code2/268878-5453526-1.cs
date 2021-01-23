    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Do whatever checking you need here
            // If you want the base check as well (against users/roles) call
            base.OnAuthorization(filterContext);
        }
    }
