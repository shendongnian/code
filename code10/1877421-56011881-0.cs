    public class GetMiddleware
    {
        private RequestDelegate _next;
        
        public GetMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/whatever")
            {
                context.Response.Headers.Add("Location", "https://example.com");
                context.Response.StatusCode = 302;
                return Task.CompletedTask;
            }
            return _next.Invoke(context);
        }
    }
