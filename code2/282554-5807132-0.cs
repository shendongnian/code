    public static bool IsBoxed<T>(T value)
    {
        return 
            (typeof(T).IsInterface || typeof(T) == typeof(object)) &&
            value.GetType().IsValueType;
    }
