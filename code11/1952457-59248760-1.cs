    public static IEnumerable<TEnum> SingleFlagEnumValues<TEnum>() where TEnum: struct, Enum
    {
        var type = typeof(TEnum);
        foreach (int value in Enum.GetValues(type))
        {
            if (IsPowerOfTwo(value))
                yield return (TEnum)(object)value;
        }
    }
