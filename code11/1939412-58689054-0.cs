    // Extension method used to add the middleware to the HTTP request pipeline.
        public static class ErrorHandlingMiddlewareExtensions
        {
            public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<ErrorHandlingMiddleware>();
            }
        }
