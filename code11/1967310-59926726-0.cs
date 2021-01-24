    public class Startup
    {
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApiVersionDescriptionProvider provider,
            VersionedODataModelBuilder builder)
        {
            app.UseMiddleware<ErrorHandling>();
ErrorHandling.cs
    public class ErrorHandling
    {
        public ErrorHandling(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Error handling code here
            // For example if you want to set a specific statusCode
            context.Response.StatusCode = MySpecificStatusCode;
