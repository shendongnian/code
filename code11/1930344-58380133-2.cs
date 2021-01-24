    public class RequestResponseLoggingMiddleware : IMiddleware
    {
        IActionLogPublish logPublish;
    
        public RequestResponseLoggingMiddleware(IActionLogPublish logPublish)
        {
            this.logPublish = logPublish;
        }
    
        // ...
    
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //...
        }
    
        //...
    }
