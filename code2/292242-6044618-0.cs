    public class TestActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             filterContext.HttpContext.Response.Redirect("loginurl");
             //or throw exception or some other action
        }
    }
