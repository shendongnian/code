 public class NopStartup : INopStartup
 {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MvcOptions>(config =>
            {
                config.Filters.Add<YourCustomActionFilter>();
            });
        }
        public void Configure(IApplicationBuilder application)
        {
        }
        public int Order => 0;
    }
Step 2 : 
public class YourCustomActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!(context.ActionDescriptor is ControllerActionDescriptor actionDescriptor)) return;
        if (actionDescriptor.ControllerTypeInfo == typeof(CustomerController) &&
            actionDescriptor.ActionName == "Register" &&
            context.HttpContext.Request.Method == "GET")
        {
                    string controllerName = nameof(YourCustomController).Replace("Controller", "");
                    string actionName = nameof(YourCustomController.YourCustomAction);
                    var values = new RouteValueDictionary(new
                    {
                        action = actionName,
                        controller = controllerName
                    });
                    context.Result = new RedirectToRouteResult(values);
        }
    }
}
With this approach, you can cut down the registration process and add some extra check/process then you can go on the registration process.
