    public class JsonRequestAttribute : AuthorizeAttribute
    {
        /*
         * 
         *   CONFIRM that this is REALLY a JSON request.
         *   This will mitigate the risk of a CSRF attack
         *   which masquerades an "application/x-www-form-urlencoded" request
         *   as a JSON request
         * 
         */
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
             if (!filterContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
             {
                 // This request is masquerading as a JSON request, kill it.
                 JsonResult unauthorizedResult = new JsonResult();
                 unauthorizedResult.Data = "Invalid request";
                 unauthorizedResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                 filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                 filterContext.Result = unauthorizedResult;
             }
        }
    }
