    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using StructureMap;
    namespace YourAppNamespace.Website.IoC
    {
        public class SmDependencyResolver : IDependencyResolver
        {
            private readonly IContainer _container;
    
            public SmDependencyResolver(IContainer container)
            {
                _container = container;
            }
    
            public object GetService(Type serviceType)
            {
                if (serviceType == null)
                {
                    return null;
                }
                try
                {
                    return _container.GetInstance(serviceType);
                }
                catch
                {
                    return null;
                }
            }
    
            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _container.GetAllInstances(serviceType).Cast<object>(); ;
            }
        }
    }
