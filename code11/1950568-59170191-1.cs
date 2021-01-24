    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
    
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            //do something
            //line below writes response
            await context.Response.WriteAsync($"Hello{CultureInfo.CurrentCulture.DisplayName}");
            //do something
            //line below passes request to next middleware
            await _next(httpContext);
            //do something
        }
    }
