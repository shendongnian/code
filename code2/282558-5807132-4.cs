    public static bool IsBoxed<T>(T value)
    {
        return 
            (typeof(T).IsInterface || typeof(T) == typeof(object)) &&
            value != null &&
            value.GetType().IsValueType;
    }
