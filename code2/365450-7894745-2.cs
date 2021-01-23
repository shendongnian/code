    public delegate bool TryFunction<T>(out T result);
    T SomeMethod(TryFunction<T> func)
    {
        T value;
    
        if(func(out value))
        {
    
        }
    }
