    public bool MyGenericMethod<T>()
    {
        // if (T is IEnumerable) // don't do this
        if (typeof(T).GetInterface("IEnumerable") == null)
            return false;
    
        // ...
        return true;
    }
