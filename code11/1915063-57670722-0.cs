    public class SimplifiedServiceProvider
    {
        private Dictionary<Type, object> mainCache = new Dictionary<Type, object>();
        private Dictionary<Type, object> scopeCache = new Dictionary<Type, object>();
        public object GetService(Type type)
        {
             var serviceLifetime = GetLifetimeForService(type);
             if (serviceLifetime == ServiceLifetime.Transient)
             {
                 // transients are created directly
                 return CreateNewInstance(type);
             }
             else if (serviceLifetime == ServiceLifetime.Singleton)
             {
                 // try to get from the cache
                 if (!mainCache.TryGetValue(type, out var service))
                 {
                     // create the service first
                     service = CreateNewInstance(type);
                     mainCache.Add(type, service);
                 }
                 return service;
             }
             else if (serviceLifetime == ServiceLifetime.Scoped)
             {
                 // try to get from the scope cache
                 if (!scopeCache.TryGetValue(type, out var service))
                 {
                     // create the service first
                     service = CreateNewInstance(type);
                     scopeCache.Add(type, service);
                 }
                 return service;
             }
        }
        public void DisposeScope()
        {
            // dispose all created (disposable) instances
            foreach (var instance in scopeCache.Values)
                (instance as IDisposable)?.Dispose();
            // reset cache
            scopeCache.Clear();
        }
        private ServiceLifetime GetLifetimeForService(Type type) { … }
        private object CreateNewInstance(Type type) { … }
    }
