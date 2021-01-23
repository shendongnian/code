    public class PermissionsAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // the best place for your authorization logic
        }
    }
