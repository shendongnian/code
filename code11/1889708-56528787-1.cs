    public class ApplicationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.TryGetValue("Application", out var values))
            {
                // Method 1: This allows you to specify a parameter on your action
                context.ActionArguments.Add("application", values.First());
                // Method 2: This adds the value into the route data
                context.RouteData.Values.Add("Application", values.First());
                // Method 3: This will set a property on your controller
                if (context.Controller is BaseApplicationController baseController)
                {
                    baseController.Application = values.First();
                }
            }
            base.OnActionExecuting(context);
        }
    }
