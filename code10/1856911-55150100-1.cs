ConcurrentDictionary<string, T> cache = new ConcurrentDictionary<string, T>();
...
cache.GetOrAdd("someKey", (key) =>
{
  var data = PullDataFromDatabase(key);
  return data;
});
There are two more things to take care about.
### Expiry
Instead of saving `T` as the value of the dictionary, you can define a type
struct CacheItem<T>
{
    public T Item { get; set; }
    public DateTime Expiry { get; set; }
}
And store the cache as a `CacheItem` with a defined expiry.
cache.GetOrAdd("someKey", (key) =>
{
    var data = PullDataFromDatabase(key);
    return new CacheItem<T>() { Item = data, Expiry = DateTime.UtcNow.Add(TimeSpan.FromHours(1)) };
});
Now you can implement expiration in an asynchronous thread.
Timer expirationTimer = new Timer(ExpireCache, null, 60000, 60000);
...
void ExpireCache(object state)
{
    var needToExpire = cache.Where(c => DateTime.UtcNow >= c.Value.Expiry).Select(c => c.Key);
    foreach (var key in needToExpire)
    {
        cache.TryRemove(key, out CacheItem<T> _);
    }
}
Once a minute, you search for all cache entries that need to be expired, and remove them.
### "Locking"
Using `ConcurrentDictionary` guarantees that simultaneous read/writes won't corrupt the dictionary or throw an exception.
But, you can still end up with a situation where two simultaneous reads cause you to fetch the data from the database twice.
One neat trick to solve this is to wrap the value of the dictionary with `Lazy`
ConcurrentDictionary<string, Lazy<CacheItem<T>>> cache = new ConcurrentDictionary<string, Lazy<CacheItem<T>>>();
...
var data = cache.GetOrData("someKey", key => new Lazy<CacheItem<T>>(() => 
{
    var data = PullDataFromDatabase(key);
    return new CacheItem<T>() { Item = data, Expiry = DateTime.UtcNow.Add(TimeSpan.FromHours(1)) };
})).Value;
**Explanation**
with `GetOrAdd` you might end up invoking the "get from database if not in cache" delegate multiple times in the case of simultaneous requests.
However, `GetOrAdd` will end up using only one of the values that the delegate returned, and by returning a `Lazy`, you guaranty that only one `Lazy` will get invoked.
