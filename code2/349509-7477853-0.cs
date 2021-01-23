    public static void AsType<T>(object o, Action<T> action) where T : class
    {
        var value = o as T;
        if (value != null)
        {
            action(value);
        }
    }
