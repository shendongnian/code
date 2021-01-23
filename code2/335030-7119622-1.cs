    public class CachedSuperCleverProvider : SomeProviderWrapper
    {
        public CachedSuperCleverProvider(ISomeProvider wrapped) : base(wrapped) { }
    
        private object UsingCache<T>(string cacheKey, Func<T> eval)
        {
            throw new NotImplementedException();
        }
    
        public override object GetFoo1()
        {
            return UsingCache("foo1", WrappedProvider.GetFoo1);
        }
    }
