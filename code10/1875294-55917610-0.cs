public class CustomExceptionFilter : IExceptionFilter
{
    private ILogger<CustomExceptionFilter> _logger;
    public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
    {
        this._logger = logger;
    }
    public void OnException(ExceptionContext context)
    {
        var ex = context.Exception;
        var c = (ControllerActionDescriptor) context.ActionDescriptor;
        if(c == null){
            context.Result = new StatusCodeResult(500);
        } else if (typeof(JsonResult) == c.MethodInfo.ReturnType) {
            context.Result = new JsonResult(new { success = false, error = "unknown" });
        } else {
            // Redirect
            this._logger.LogCritical(ex,ex.Message);
            context.Result = new RedirectResult("/Error/ErrorPage");
        }
    }
}
and register this filter as below :
services.AddMvc(routes => {
    routes.Filters.Add(typeof(CustomExceptionFilter));
});
it works fine for me.
