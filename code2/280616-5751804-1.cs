    public class SomeClass
    {
        private readonly ICacheProvider _cacheProvider;
    
        public SomeClass(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }
        public string GetSomeMetaData()
        {
            return _cacheProvider.Get("magicKey");
        }
    }
