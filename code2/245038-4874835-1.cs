        public class MyDependencyResolver : IDependencyResolver
        {
            private IKernel kernel;
    
            public MyDependencyResolver(IKernel kernel)
            {
                this.kernel = kernel;
            }
    
            public object GetService(Type serviceType)
            {
                return kernel.TryGet(serviceType);
            }
    
            public IEnumerable<object> GetServices(Type serviceType)
            {
                return kernel.GetAll(serviceType);
            }
        }
