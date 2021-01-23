    foreach (var item in coolList)
    {
        Type t = item.GetType();
        if (t.IsPrimitive || _cache.GetOrAdd(t, _factory))
        {
            Console.WriteLine(item);
        }
    }
    // ...
    private static readonly ConcurrentDictionary<Type, bool> _cache =
        new ConcurrentDictionary<Type, bool>();
    private const BindingFlags _flags =
        BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
    private static readonly Func<Type, bool> _factory =
        t => t.GetMethod("ToString", _flags, null, Type.EmptyTypes, null) != null;
