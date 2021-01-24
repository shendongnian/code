    public class YourFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var yourParams = context.ActionArguments;
            //do your validation, control
        }
    }
