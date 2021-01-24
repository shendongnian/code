class CacheEventListener<TK, TV> : ICacheEntryEventListener<TK, TV>
{
    private readonly string _cacheName;
    [InstanceResource]  // Injected automatically.
    private readonly IIgnite _ignite = null;
    private ICache<TK, TV> _cache;
    public CacheEventListener(string cacheName)
    {
        _cacheName = cacheName;
    }
    public void OnEvent(IEnumerable<ICacheEntryEvent<TK, TV>> events)
    {
        _cache = _cache ?? _ignite.GetCache<TK, TV>(_cacheName);
        foreach (var entryEvent in events)
        {
            if (entryEvent.EventType == CacheEntryEventType.Created && _cache.Remove(entryEvent.Key))
            {
                // Run consumer logic here - use another thread for heavy processing.
                Consume(entryEvent.Value);
            }
        }
    }
}
Then we deploy this to every node with a single call:
var consumer = new CacheEventListener<Guid, string>(cache.Name);
var continuousQuery = new ContinuousQuery<Guid, string>(consumer);
cache.QueryContinuous(continuousQuery);
As a result, `OnEvent` is called once per entry on the primary node for that entry. So there is one consumer per Ignite node. We can increase effective number of consumers per node by offloading actual consumer logic to other threads, using `BlockingCollection` and so on.
And one last thing - we have to come up with a unique cache key for every new entry. Simplest thing is `Guid.NewGuid()`, but we can also use `AtomicSequence`.
