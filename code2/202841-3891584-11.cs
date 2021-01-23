    T GetOrAdd<T> (string cachekey, Func<T> fnGetItem);
    R[] GetOrAdd<T,R> (string cachekey, Func<IEnumerable<T>> fnGetItem);
    // now we can do:
    var customer = Cache.GetOrAdd("First", _ => context.Customers.First());
    var customers = Cache.GetOrAdd<Customer,Customer>("All", () => context.Customers.ToArray());
