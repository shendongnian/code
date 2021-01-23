    public class SqlConnectionActionFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var sessionController = filterContext.Controller;
    
                if (filterContext.IsChildAction)
                    return;
    
                //Create your SqlConnection here
            }
    
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                if (filterContext.IsChildAction)
                    return;
    
                //Commit transaction & Teardown SqlConnection
            }
        }
