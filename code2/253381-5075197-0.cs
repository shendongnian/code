    public class UnityControllerFactory : DefaultControllerFactory 
    {
        private readonly IUnityContainer container; 
        public UnityControllerFactory(IUnityContainer container) 
        { 
            this.container = container; 
        } 
        protected override IController GetControllerInstance(
            RequestContext requestContext, 
            Type controllerType
        ) 
        { 
            return container.Resolve(controllerType) as IController; 
        }
    }
