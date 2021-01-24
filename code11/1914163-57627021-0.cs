C#
public class PersistStore : IPersistedGrantStore
    {
        private readonly IPersistedGrandStoreService _persistedGrandStore;
        public PersistStore(IPersistedGrandStoreService persistedGrandStore)
        {
            _persistedGrandStore = persistedGrandStore;
        }
        public Task StoreAsync(PersistedGrant grant)
        {
            return _persistedGrandStore.AddAsync(grant.ToPersistedGrantModel());
        }
        public async Task<PersistedGrant> GetAsync(string key)
        {
            var grant = await _persistedGrandStore.GetAsync(key);
            return grant.ToPersistedGrant();
        }
        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            var grants = await _persistedGrandStore.GetAllAsync(subjectId);
            return grants.ToPersistedGrants();
        }
        public Task RemoveAsync(string key)
        {
            return _persistedGrandStore.RemoveAsync(key);
        }
        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            return _persistedGrandStore.RemoveAllAsync(subjectId, clientId);
        }
        public Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            return _persistedGrandStore.RemoveAllAsync(subjectId, clientId, type);
        }
    }
