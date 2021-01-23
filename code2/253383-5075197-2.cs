    public class UnityControllerFactory : DefaultControllerFactory 
    {
        private readonly IUnityContainer _container; 
        public UnityControllerFactory(IUnityContainer container) 
        { 
            _container = container; 
        }
        protected override IController GetControllerInstance(
            RequestContext requestContext, 
            Type controllerType
        ) 
        { 
            return _container.Resolve(controllerType) as IController; 
        }
    }
