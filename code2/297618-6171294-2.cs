    public class LocalizationAwareAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContext = filterContext.HttpContext.Current;
            if (!httpContext.Cookies.Keys.Contains("language"))
            {
                httpContext.Response.AppendCookie(new HttpCookie("language", 1));
            }
            if (!httpContext.Cookies.Keys.Contains("country"))
            {
                httpContext.Response.AppendCookie(new HttpCookie("country", 7));
            }
        }
    }
