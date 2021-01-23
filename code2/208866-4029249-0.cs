    public class LoggingActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var controllerName = filterContext.Controller.ControllerContext.RouteData.Values["controller"];
            var actionName = filterContext.Controller.ControllerContext.RouteData.Values["action"];
        }
    }
