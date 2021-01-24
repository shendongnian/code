    public static IEnumerable<(int, TEnum)> GetValues<TEnum>()
    where TEnum : struct, Enum
    {
        foreach (TEnum item in Enum.GetValues(typeof(TEnum)))
        {
            yield return ((int)(object)item, item);
        }
    }
