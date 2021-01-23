    public class Service : IService
    {
        private readonly IProviderFactory _providerFactory;
    
        public Service(IProviderFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException("factory", "providerfactory cannot be null");
            _proiderFactory = factory;
        }
    
        public void Load(string providerName)
        {
          var provider = _providerFactory.GetNamedInstance(providerName);
          // do some operation on provider
        }
    }
