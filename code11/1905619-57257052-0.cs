    public class LoggingPropertiesFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
            ControllerBase controllerBase = context.Controller as ControllerBase;
            if(controllerBase != null)
            {
                var routeAction = controllerBase.RouteData.Values["action"];
                LogContext.PushProperty("method", routeAction);
                
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
The only issue I have with this so far is that I have to manually attach an attribute to each action for this to work, but this does solve the initial problem I had if it's any use to anyone.
