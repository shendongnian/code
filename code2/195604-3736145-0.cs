    // This can't really be *properly* statically typed
    private readonly Dictionary<Type, object> typeMap = new 
        Dictionary<Type, object>();
    public Foo Initialize(IEnumerable<Type> types)
    {
       Type genericListType = typeof(List<>);
       foreach(var type in types)
       {
           // MakeGenericType is really badly named
           Type constructedListType = genericListType.MakeGenericType(type);
           typeMap[type] = Activator.CreateInstance(constructedListType);
       }
    }
    
    // We can't express this particularly safely either,
    // although we *could* return the non-generic IList
    public object SomeTypeData(Type type)
    {
        return typeMap[type];
    }
    // This *is* statically typed, although we need to cast inside
    public IList<T> SomeTypeData<T>()
    {
        return (IList<T>) typeMap[typeof(T)];
    }
