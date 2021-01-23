    public class NinjectResourceFactory : IResourceFactory
    {
        private readonly IKernel _kernel;
        public NinjectResourceFactory(IKernel kernel)
        {
            _kernel = kernel;
        }
        public object GetInstance(Type serviceType, InstanceContext instanceContext, HttpRequestMessage request)
        {
            return _kernel.Get(serviceType);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object service)
        {
            // no op
        }
    }
