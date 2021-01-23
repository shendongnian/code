    public class MyCustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!(filterContext.Result is HttpUnauthorizedResult))
            {
                var currentUser = filterContext.HttpContext.User.Identity.Name;
                var currentAction = filterContext.RouteData.GetRequiredString("action");
                var id = filterContext.RouteData.Values["id"];
                if (!HasAccess(currentAction, currentUser, id))
                {
                    HandleUnauthorizedRequest(filterContext);
                }
            }
        }
        private bool HasAccess(string currentAction, string currentUser, object id)
        {
            // TODO: decide whether this user is allowed to access this id on this action
            throw new NotImplementedException();
        }
    }
