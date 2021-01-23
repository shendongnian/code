    using Castle.Core;
    using Castle.MicroKernel;
    using Castle.MicroKernel.ModelBuilder;
    
    ...
    
    public class InterceptorContributor : IContributeComponentModelConstruction
    {
        private readonly InterceptorReference interceptor;
    
        public InterceptorContributor(InterceptorReference interceptor)
        {
            this.interceptor = interceptor;
        }
    
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            if (...)
            {
                model.Interceptors.Add(interceptor)
            }
        }
    }
