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
        // if arg could be an IList<T>
        t = arg.GetType().GetInterface(typeof(IList<>).Name).GetGenericArguments()[0];
    }
