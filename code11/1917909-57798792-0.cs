    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context )
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
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            string message = "Something is wrong!";
           
            httpStatusCode = HttpStatusCode.BadRequest; // Or whatever status code you want to return
            message = exception.Message; // Or whatever message you want to return
            string result = JsonConvert.SerializeObject(new
            {
                error = message,
               
            });
            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
