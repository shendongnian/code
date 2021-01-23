    public static bool IsBoxed<T>(T item)
    {
        return (default(T) == null);
    }
    public static bool IsBoxed<T>(T? item) where T : struct
    {
        return false;
    }
