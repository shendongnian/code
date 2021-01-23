    public sealed class NamedDelegateFactory<T> : INamedFactory<T>
    {
        private readonly Func<string, T> factory;
        public NamedDelegateFactory(Func<string, T> factory)
        {
            this.factory = factory;
        }
        public T GetByKey(string key)
        {
            return this.factory(key);
        }
        object INamedFactory.GetByKey(string key)
        {
            return this.factory(key);
        }
    }
