`
public class CustomFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var session = new BusinessLayer.User(filterContext.RequestContext.HttpContext.Request.Cookies["appname"]);
        if (!session.IsAdminUser())
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary { {"controller", "YourControllerName"}, {"action", "Index"} });
        }
        base.OnActionExecuting(filterContext);
    }
    // if you want, here are the rest of the overrides, but I only use OnActionExecuting
    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        base.OnActionExecuted(filterContext);
    }
    
    public override void OnResultExecuting(ResultExecutingContext filterContext)
    {
        base.OnResultExecuting(filterContext);
    }
    public override void OnResultExecuted(ResultExecutedContext filterContext)
    {
        base.OnResultExecuted(filterContext);
    }
}
`
and then decorate your Action methods with `[CustomFilter]`. 
(You'll have to supply the correct Controller name and possibly supply more values in the RouteValueDictionary depending on your route definition.)
