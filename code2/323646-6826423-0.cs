    public class ProfilerAttribute : FilterAttribute, IActionFilter, IResultFilter, IExceptionFilter {
        public void OnActionExecuting(ActionExecutingContext filterContext) {
            Debug.WriteLine("Before Action is executing");
        }
    
        public void OnActionExecuted(ActionExecutedContext filterContext) {
            Debug.WriteLine("After Action is executed");
        }
    
        public void OnResultExecuted(ResultExecutedContext filterContext) {
            Debug.WriteLine("After Action Result is executed");            
        }
    
        public void OnResultExecuting(ResultExecutingContext filterContext) {
            Debug.WriteLine("Before Action Result is executing");
        }
    
        public void OnException(ExceptionContext filterContext) {
            Debug.WriteLine("oops! exception");
        }
    }
    
