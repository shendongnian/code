    public static T GetAttribute<T>(this Enum val)
        where T : Attribute
    {
        return (T)val
        .GetType()
        .GetField(val.ToString())
        .GetCustomAttribute(typeof(T), false);
    }
