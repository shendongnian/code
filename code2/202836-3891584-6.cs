     T GetOrAdd<T> (string cachekey, Func<object,T> fnGetItem)
    T[] GetOrAdd<T> (string cachekey, Func<IEnumerable<T>> fnGetItem)
    // now we can do:
    var customer = Cache.GetOrAdd("First", _ => context.Customers.First());
    var customers = Cache.GetOrAdd("All", () => context.Customers.ToArray());
