    using System;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    
    namespace WebProveidorsMVC.DI.ControllerFactories
    {
        public class UnityControllerFactory : DefaultControllerFactory
        {
            private readonly IUnityContainer _container;
    
            public UnityControllerFactory()
            {
                _container=new UnityContainer();
    
                ((UnityConfigurationSection) ConfigurationManager.GetSection("unity")).Configure(_container);
    
                var controllerTypes = from t in Assembly.GetCallingAssembly().GetTypes()
                                      where typeof(IController).IsAssignableFrom(t)
                                      select t;
    
                foreach (var t in controllerTypes)
                    _container.RegisterType(t, t.FullName);
            }
    
            protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
            {
                if (controllerType != null)
                    return (IController)_container.Resolve(controllerType);
                return null;
            }
    
            public override void ReleaseController(IController controller)
            {
                _container.Teardown(controller);
                base.ReleaseController(controller);
            }
        }
    }
