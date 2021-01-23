    static IEnumerable<IEnumerable<T>> castList<T>(List<List<object>> list) {
        return list.Select(x => x.Cast<T>());
    }
    void DoSomething(Type myT, List<List<object>> list) {
        object untyped = typeof(MyClass).GetMethod("castList")
            .MakeGenericMethod(myT)
            .Invoke(null, new[] { list });
        // untyped is an IEnumerable<IEnumerable<myT>> at runtime, 
        // but obviously you don't know that at compile time.
        
        // what can you do with untyped? 
        // 1: use it like an untyped container
        var option1 = (IEnumerable<IEnumerable>)untyped;
        foreach(var inner in option1)
            foreach(object item in inner)
                Console.WriteLine(object);
        // 2: pass it to a function that you reflect on using
        //    the above makeGenericMethod strategy
        typeof(MyClass).GetMethod("Process")
            .MakeGenericMethod(myT)
            .Invoke(null, new[] { untyped });
        // 3: Cast it conditionally
        switch(Type.GetTypeCode(myT)) {
            case TypeCode.Int32:
                 Process((IEnumerable<IEnumerable<int>>)untyped);
                 break;
            case TypeCode.Single:
                 Process((IEnumerable<IEnumerable<float>>)untyped);
                 break;
        }
        // 4: make it a dynamic
        dynamic dyn = untyped;
        Process(dyn);
    }
    static void Process<T>(IEnumerable<IEnumerable<T>> ienumerable) {
        Console.WriteLine("Processing type: {0}", typeof(T).Name);
        foreach(var inner in ienumerable)
            foreach(T item in inner)
                DoSomething(item); // item is now type T
    }
