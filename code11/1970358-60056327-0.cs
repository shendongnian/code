    public class MyClass
    {
        private readonly IPersistedGrantStore _store;
        public MyClass(IPersistedGrantStore store)
        {
            _store = store;
        }
        public async Task Something(string sub)
        {
            var persistedGrants = await _store.GetAllAsync(sub);
        }
    }
