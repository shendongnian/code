    public class SiteControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }
            
            // Create controller class. Here.
            IController controller = (IController)Activator.CreateInstance(controllerType)
            
            if (typeof(Controller).IsAssignableFrom(controllerType))
            {
                Controller controllerInstance = controller as Controller;
                
                if (controllerInstance != null)
                {
                    controllerInstance.ActionInvoker = new DiagControllerActionInvoker();
                }
            }
            
            return controller;
        }
    }
