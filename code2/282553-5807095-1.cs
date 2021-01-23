    public static bool IsBoxed(object item)
    {
        return true;
    }
    public static bool IsBoxed<T>(T item) where T : struct
    {
        return false;
    }
