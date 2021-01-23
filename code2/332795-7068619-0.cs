    public static object GetDefault(this Type t)
    {
        return t.IsValueType ? Activator.CreateInstance(t) : null;
    }
    public static T GetDefault<T>()
    {
        var t = typeof(T);
        return (T) GetDefault(t);
    }
    public static bool IsDefault<T>(T other)
    {
        T defaultValue = GetDefault<T>();
        if (other == null) return defaultValue == null;
        return other.Equals(defaultValue);
    }
