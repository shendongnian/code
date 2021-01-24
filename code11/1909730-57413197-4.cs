    public sealed class CoreDependencyResolver : System.Web.Mvc.IDependencyResolver {
        private readonly System.Web.Mvc.IDependencyResolver mvcInnerResolver;
        private readonly IServiceProvider serviceProvider;
                    
        public CoreDependencyResolver(IServiceProvider serviceProvider, System.Web.Mvc.IDependencyResolver dependencyResolver) {
            this.serviceProvider = serviceProvider;
            mvcInnerResolver = dependencyResolver;
        }
        public object GetService(Type serviceType) {
            object result = this.serviceProvider.GetService(serviceType);
            if (result == null && mvcInnerResolver != null)
                result = mvcInnerResolver.GetService(serviceType);
            return result;
        }
        public IEnumerable<object> GetServices(Type serviceType) {
            IEnumerable<object> result = this.serviceProvider.GetServices(serviceType);
            if (result == null && mvcInnerResolver != null)
                result = mvcInnerResolver.GetServices(serviceType);
            return result ?? new object[0];
        }
    }
    
