    public class SpringActionInvoker : ControllerActionInvoker
    {
        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            IObjectFactory objectFactory = ContextRegistry.GetContext();
            //use objectFactory to inject dependencies into filters
        }
    }
