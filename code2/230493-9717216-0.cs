    public sealed class MyAttribute  : ActionFilterAttribute
    {
        /// <summary>
        /// Called by MVC just before the result (typically a view) is executing.
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var result = filterContext.Result;
            if (result is ViewResultBase)
            {
                var response = filterContext.HttpContext.Response;
                
                // Check your request parameters and attach filter.
            }
        }
