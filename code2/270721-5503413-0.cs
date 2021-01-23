    public static bool IsNullOrInvalid<T>(this System.Nullable<T> source, T invalid)
        where T: struct, IEquatable<T>
    {
        return (source == null || source.Value.Equals(invalid));
    }
