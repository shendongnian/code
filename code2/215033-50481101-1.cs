    public static IEnumerable<T> GetUniqueFlags<T>(this Enum flags)
        where T : Enum    // New constraint for C# 7.3
    {
        foreach (Enum value in Enum.GetValues(input.GetType()))
            if (input.HasFlag(value))
                yield return (T)value;
    }
