    public class MyControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance
            (RequestContext requestContext, Type controllerType)
        {
            try
            {
                var controller = base.GetControllerInstance(requestContext, controllerType);
                requestContext.HttpContext.User = Thread.CurrentPrincipal = new 
                                                        MyPrincipal();
                return controller;
            }
            catch (Exception)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }
    }
