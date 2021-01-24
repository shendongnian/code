    // Name TryCreate is a bit better because this method will return null if cast fails
    public T TryCreate<T>() where T : class, I<T>
    {
        if (typeof(T) == typeof(A))
        {
            return new A("A") as T;
        }
        if (typeof(T) == typeof(B))
        {
            return new B(2) as T;
        }
        throw new Exception("Unknown className");
    }
