	public class WindsorControllerFactory : DefaultControllerFactory
	{
		private readonly IWindsorContainer _container;
		public WindsorControllerFactory(IWindsorContainer container)
		{
			_container = container;
		}
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			return (IController)_container.Resolve(controllerType);
		}
		public override void ReleaseController(IController controller)
		{
			_container.Release(controller);
		}
	}
