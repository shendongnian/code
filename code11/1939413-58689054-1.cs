     public class ErrorHandlingMiddleware
        {
            private readonly RequestDelegate _next;
    
            public ErrorHandlingMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext httpContext)
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(httpContext, ex);
                }
            }
    
            private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
              // Implement how you want to handle the error.
            }
    }
