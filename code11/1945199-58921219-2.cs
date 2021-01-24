    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext actionContext)
        {
            actionContext.Result = new HttpStatusCodeResult(
                HttpStatusCode.Forbidden, 
                "Custom message goes here");
        }
    }
