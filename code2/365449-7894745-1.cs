    public delegate bool TryFunction<T>(out T result);
    T SomeMethod(TryFunction func)
    {
        T value;
    
        if(func(out value))
        {
    
        }
    }
