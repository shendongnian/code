    public class LightInjectTypeResolver : ITypeResolver
    {
        private readonly IServiceFactory _serviceFactory;
        public LightInjectTypeResolver(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
        public object GetType(Type entity)
        {
            return _serviceFactory.GetInstance(entity);
        }
    }
