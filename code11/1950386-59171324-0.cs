    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate nextDelegate;
        public ErrorHandlingMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }
        public async Task Invoke(HttpContext context, IOptions<MvcJsonOptions> options)
        {
            try
            {
                await this.nextDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, options);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception ex, IOptions<MvcJsonOptions> options)
        {
            var httpStatusCode = HttpStatusCode.InternalServerError;
            PathString originalPath = context.Request.Path;
            context.Request.Path = "/Error/StatusCode" + (int)httpStatusCode;
            try
            {
                var exceptionHandlerFeature = new ExceptionHandlerFeature()
                {
                    Error = ex,
                    Path = originalPath.Value,
                };
                context.Features.Set<IExceptionHandlerFeature>(exceptionHandlerFeature);
                context.Features.Set<IExceptionHandlerPathFeature>(exceptionHandlerFeature);
                context.Response.StatusCode = (int)httpStatusCode;
                await this.nextDelegate(context);
                return;
            }
            catch (Exception ex2)
            {
            }
            finally
            {
                context.Request.Path = originalPath;
            }
        }
    }
