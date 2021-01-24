    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseWideOpenCors(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WideOpenCorsMiddleware>();
        }
    }
