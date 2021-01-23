    internal sealed class CustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var instance = base.GetControllerInstance(requestContext, controllerType);
            var controller = instance as Controller;
            if (controller != null)
                controller.ActionInvoker = new CustomControllerActionInvoker();
            return instance;
        }
    }
