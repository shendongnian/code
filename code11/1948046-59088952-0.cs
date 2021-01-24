public async Task<IEnumerable<Document>> GetEventsForDay(string dayKey)
{
    CheckCacheKeyExists(dayKey);
    var cachedItem = await _cache.GetOrCreateAsync(dayKey, async entry =>
        {
            await Task.Delay(100).ConfigureAwait(false); // this would also stop the deadlock
            entry.SetOptions(_cacheEntryOptions);
            var events = await EventsForDay(dayKey);
            return events;
        });
    return cachedItem;
}
and so would this:
public async Task<IEnumerable<Document>> GetEventsForDay(string dayKey)
{
    CheckCacheKeyExists(dayKey);
    var cachedItem = await _cache.GetOrCreateAsync(dayKey, async entry =>
        {
            SynchronizationContext.SetSynchronizationContext(null); // this would stop it too
            entry.SetOptions(_cacheEntryOptions);
            var events = await EventsForDay(dayKey);
            return events;
        });
    return cachedItem;
}
