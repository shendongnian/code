    public class TracerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var modelValues = actionContext.ActionArguments["mymodel"] as Mymodel ;
       
        }
    }
