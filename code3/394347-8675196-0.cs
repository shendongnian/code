     public class TraceActionAttribute : ActionFilterAttribute
    {
        private IDisposable logManagerBeginTrace;
    
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            List<object> parameters = new List<object>();
    
            string actionName = filterContext.ActionDescriptor.ActionName;
            Type controllerType = filterContext.Controller.GetType();
            foreach (KeyValuePair<string, object> currentParameter in filterContext.ActionParameters)
            {
                parameters.Add(currentParameter.Value);
            }
    
            filterContext.HttpContext.Items["TraceActionKey"] = LogManager.BeginMethodTrace(ApplicationConstants.ApplicationName, controllerType, actionName, Guid.NewGuid(), parameters.ToArray());
        }
    
        /// <summary>
        /// Called by the ASP.NET MVC framework after the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            ((IDisposable)filterContext.HttpContext.Items["TraceActionKey"]).Dispose();
        }
    }
