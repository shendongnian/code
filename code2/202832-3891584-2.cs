    void R GetOrAdd<T> (string cachekey, Func<T> fnGetItem);
    void R[] GetOrAdd<T,R> (string cachekey, Func<IEnumerable<T>> fnGetItem);
    // now we can do:
    var customer = Cache.GetOrAdd("First", _ => context.Customers.First());
    var customers = Cache.GetOrAdd<Customer,Customer>("All", () => context.Customers.ToArray());
