    void GetOrAdd<T> (string cachekey, Func<object,T> fnGetItem, out T);
    void GetOrAdd<T> (string cachekey, Func<IEnumerable<T>> fnGetItem, out T[])
    // now we can write:
    Customer customer;
    Cache.GetOrAdd("First", _ => context.Customers.First(), out customer);
    Customer[] customers;
    var customers = Cache.GetOrAdd("All", 
                                   () => context.Customers.ToArray(), out customers);
