    public class FireFoxOnlyAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var userAgent = filterContext.HttpContext.Request.Headers["User-Agent"];
            if (!IsFirefox(userAgent))
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Unauthorized.cshtml"
                };
            }
        }
        private bool IsFirefox(string userAgent)
        {
            // up to you to implement this method. You could use
            // regular expressions or simple IndexOf method or whatever you like
            throw new NotImplementedException();
        }
    }
