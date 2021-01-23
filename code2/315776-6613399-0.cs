    public static bool IsDefault(object value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        return (bool)typeof(Program).GetMethod("IsDefaultGeneric")
                                    .MakeGenericMethod(value.GetType())
                                    .Invoke(null, new object[] { value });
    }
    public static bool IsDefaultInternal<T>(T value)
        where T : struct, IEquatable<T>
    {
        return value.Equals(default(T));
    }
