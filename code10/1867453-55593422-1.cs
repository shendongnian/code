    /// <summary>
    /// Triggers IActionFilter execution on FakeApiController
    /// </summary>
    private static async Task<HttpContext> SimulateRequest(IServiceCollection services, string methodName)
    {
        var provider = services.BuildServiceProvider();
        // Any default request headers can be set up here
        var httpContext = new DefaultHttpContext()
        {
            RequestServices = provider
        };
        // This is only necessary if MyFilterImpl is examining the Action itself
        MethodInfo info = typeof(FakeApiController)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .FirstOrDefault(x => x.Name.Equals(methodName));
        var actionContext = new ActionContext
        {
            HttpContext = httpContext,
            RouteData = new RouteData(),
            ActionDescriptor = new ControllerActionDescriptor()
            {
                MethodInfo = info
            }
        };
        var actionExecutingContext = new ActionExecutingContext(
            actionContext,
            new List<IFilterMetadata>(),
            new Dictionary<string, object>(),
            new FakeApiController()
            {
                ControllerContext = new ControllerContext(actionContext),
            }
        );
        var filter = new MyFilterImpl(provider.GetService<IDependency>());
        filter.OnActionExecuting(actionExecutingContext);
        await (actionExecutingContext.Result?.ExecuteResultAsync(actionContext) ?? Task.CompletedTask);
        return httpContext;
    }
