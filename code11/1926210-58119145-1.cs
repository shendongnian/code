    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //Capture the exception.
            string hostName = Environment.MachineName;
            string url = StringFunctions.getCurrentUrl(context.HttpContext);
            string userName = string.Empty;
            string controllerName = string.Empty;
            string actionName = string.Empty;
    
            if (context.HttpContext.User != null)
            {
                userName = context.HttpContext.User.Identity.Name;
            }
    
            controllerName = context.RouteData.Values["controller"].ToString();
            actionName = context.RouteData.Values["action"].ToString();
                    
            EventLogging.LogApplicationError(hostName, controllerName, actionName, url, userName, ex);
        }
    }
