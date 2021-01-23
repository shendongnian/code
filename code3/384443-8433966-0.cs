    [AttributeUsage(AttributeTargets.All)]
    public sealed class RecordLoggedInCountAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        { 
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect("http://google.com");
            }
        }
    }
