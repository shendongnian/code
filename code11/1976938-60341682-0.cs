    public class BaseController : Controller
    { 
        protected override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.HttpContext.Response.StatusCode == 403)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Sample",
                    action = "LoginUserAction"
                }));
            }
        }
    }
