    public T func1<T>() 
    {
        func2(typeof(T));
    }
    public object func2(Type type)
    {
        Console.WriteLine(type.FullName);
    }
