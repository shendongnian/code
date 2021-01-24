    public class YourCustomMiddleMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
    
        public YourCustomMiddleMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
    
        public async Task Invoke(HttpContext context)
        {
          
          // Your HttpContext related task is in here.
          await _requestDelegate(context);
        }
    }
