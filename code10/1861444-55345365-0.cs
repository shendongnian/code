    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AjaxAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                 filterContext.HttpContext.Response.StatusCode = 401;
                 filterContext.Result = new JsonResult
                 {
                     Data = new { Success = false, Data = "Unauthorized" },
                     ContentEncoding = System.Text.Encoding.UTF8,
                     ContentType = "application/json",
                     JsonRequestBehavior = JsonRequestBehavior.AllowGet
                 };
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
