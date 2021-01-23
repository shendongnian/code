    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (!(filterContext.Result is RedirectToRouteResult))
            {
                ...
            }
        }
    }
