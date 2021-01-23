    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        private readonly IContainer container;
        public StructureMapControllerFactory(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }
        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {
            return (IController)this.container.GetInstance(controllerType);
        }
    }
