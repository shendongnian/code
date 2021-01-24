    public static IReadOnlyCollection<T1> All<T1, T2>(this ICollection<T2> storage) where T2: T1
    {
        dynamic temp = storage;
        return new ReadOnlyCollection<T1>(new List<T1>(temp));
    }
    
    ...
    
    var list = new List<SomeChild>()
                   {
                      new SomeChild()
                   };
    
    var interfaces = list.All<ISomeBase, SomeChild>();
