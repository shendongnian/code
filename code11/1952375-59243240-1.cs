    public class CustomAttributeName : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            HttpContext.Current.Response.Write(" Output from OnActionExecuting");
        }
    
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            HttpContext.Current.Response.Write(" Output from OnActionExecuted");
        }
    }
