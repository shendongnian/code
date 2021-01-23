    public class UnityControllerFactory : DefaultControllerFactory {
		#region IControllerFactory Members
		public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName) {
			IController controller;
			controllerName = controllerName.ToLower();
			var container = ((IUnityContainer)HttpContext.Items["childContainer"])
			if(container.IsRegistered<IController>(controllerName))
				controller = container.Resolve<IController>(controllerName);
			else 
				controller = base.CreateController(requestContext, controllerName) ;
			return controller;
		}
    } 
