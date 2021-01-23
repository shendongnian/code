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
            if (controllerType == null)
            {
                throw new ArgumentNullException("controllerType");
            }
            if (!typeof(IController).IsAssignableFrom(controllerType))
            {
                throw new ArgumentException("Type requested is not a controller", "controllerType");
            }
            return _container.Resolve(controllerType) as IController; 
        }
    }
