    public class ErrorHandlingMiddleware
        {
            private readonly RequestDelegate _next;
            public ErrorHandlingMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext context /* other dependencies */)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex);
                }
            }
    
            private static Task HandleExceptionAsync(HttpContext context, Exception ex)
            {
                var code = HttpStatusCode.InternalServerError; // 500 if unexpected
                if (ex is CustomExceptionOne) code = HttpStatusCode.BadRequest;
                if (ex is CustomExceptionTwo) code = HttpStatusCode.Unauthorized;
    
                var result = JsonConvert.SerializeObject(new { error = ex.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                return context.Response.WriteAsync(result);
            }
        }
