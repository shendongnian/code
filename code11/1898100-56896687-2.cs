    public class RequestScopeDependencySetupFilter : ActionFilterAttribute
    {
        private readonly IKernel _kernel;
        public RequestScopeDependencySetupFilter(IKernel kernel)
        {
            _kernel = kernel;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var accessor = _kernel.Get<AppStateAccessor>();
            accessor.AppState = context.HttpContext.Session["appstate"] as AppState;
        }
    }
