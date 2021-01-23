    public class CustomAuthorizationAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // You need to set this action result to something other than a HttpUnauthorizedResult, 
            // this result will cause the redirection to the login page
            
            // Forbidden request... does not redirect to login page
            // filterContext.Result = new HttpStatusCodeResult(403);
            filterContext.Result = new ErrorActionResult { ErrorMessage = "Unauthorized Access" };
        }
    }
    public class ErrorActionResult : ActionResult
    {
        public string ErrorMessage { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write(this.ErrorMessage);
        }
    }
