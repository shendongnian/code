    public bool MyGenericMethod<T>()
    {
        if (T is IEnumerable)
            throw new ArgumentException("The type must not be an IEnumerable");
    
        // ...
    }
