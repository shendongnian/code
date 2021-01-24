    public class DotNetCoreDependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDependencyResolver _oldDependencyResolver;
        public DotNetCoreDependencyResolver(IServiceProvider serviceProvider, 
            IDependencyResolver oldDependencyResolver)
        {
            _serviceProvider = serviceProvider;
            _oldDependencyResolver = oldDependencyResolver;
        }
        public object GetService(Type serviceType)
        {
            var serviceScope = HttpContext.Current.Items["serviceScope"] as IServiceScope;
            return serviceScope?.ServiceProvider?.GetService(serviceType)
                ?? _serviceProvider.GetService(serviceType) 
                ?? _oldDependencyResolver.GetService(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType) 
            => _oldDependencyResolver.GetServices(serviceType);
    }
