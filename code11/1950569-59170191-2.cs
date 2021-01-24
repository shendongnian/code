    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
    
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            //do sth
            //line below writes response
            await context.Response.WriteAsync($"Hello");
            //do sth
            //line below passes request to next middleware
            await _next(httpContext);
            //do sth
        }
    }
