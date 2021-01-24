    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().Contains("animals"))
                httpContext.Response.Redirect("/animals/category-animal");
    
            return _next(httpContext);
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    
        public static class MyMiddlewareExtensions
        {
            public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<MyMiddleware>();
            }
    
    }
