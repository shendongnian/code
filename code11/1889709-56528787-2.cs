    public class ApplicationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is BaseApplicationController baseController)
            {
                baseController.Application = (string)context.RouteData.Values["application"];
            }
            base.OnActionExecuting(context);
        }
    }
