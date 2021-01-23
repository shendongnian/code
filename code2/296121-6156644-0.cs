    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, 
            string controllerName)
        {
            return base.CreateController(requestContext, controllerName.Replace("-",""));
        }
    }
