    // This adapter wraps the CSL LightCoreAdapter of LightCore itself.
    public class LightCoreServiceLocatorAdapter : IServiceLocator
    {
        private readonly LightCoreAdapter container;
        public LightCoreServiceLocatorAdapter(IContainer container)
        {
            // You need a reference to LightCore.CommonServiceLocator.dll.
            this.container = new LightCoreAdapter(container);
        }
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return this.container.GetAllInstances<TService>();
        }
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return this.container.GetAllInstances(serviceType);
        }
        public TService GetInstance<TService>(string key)
        {
            if (key == null)
            {
                return this.container.GetInstance<TService>(null);
            }
            else
            {
               // This is custom logic
               this.container.GetInstance<INamedFactory<TService>>().GetByKey(key);
            }
        }
        public TService GetInstance<TService>()
        {
            return this.container.GetInstance<TService>();
        }
        public object GetInstance(Type serviceType, string key)
        {
            if (key == null)
            {
                return this.container.GetInstance(serviceType);
            }
            else
            {
                // This is custom logic
                var facType = typeof(INamedFactory<>).MakeGenericType(serviceType);
                var factory = (INamedFactory)this.container.GetInstance(facType);
                return factory.GetByKey(key);
            }
        }
        public object GetInstance(Type serviceType)
        {
            return this.container.GetInstance(serviceType);
        }
        object IServiceProvider.GetService(Type serviceType)
        {
            ((IServiceProvider)this.container).GetService(serviceType);
        }
    }
