    void func1(List<something> arg)
    {
        Type t = typeof(something);
    }
    
    void func2<T>(List<T> arg)
    {
        Type t = typeof(T);
    }
    
    void func3(object arg)
    {
        // assuming arg is a List<T>
        Type t = arg.GetType().GetGenericArguments()[0];
    }
    void func4(object arg)
    {
        // assuming arg is an IList<T>
        Type t;
        // this assumes that arg implements exactly 1 IList<> interface;
        // if not it throws an exception indicating that IList<> is ambiguous
        t = arg.GetType().GetInterface(typeof(IList<>).Name).GetGenericArguments()[0];
        // if you expect multiple instances of IList<>, it gets more complicated;
        // we'll take just the first one we find
        t = arg.GetType().GetInterfaces().Where(
            i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>))
            .First().GetGenericArguments()[0];
    }
