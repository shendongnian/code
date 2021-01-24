    public static IEnumerable<(int, TEnum)> GetValues<TEnum>()
    where TEnum : struct, Enum
    {
        foreach (var item in Enum.GetValues(typeof(TEnum)))
        {
            yield return ((int)item, (TEnum)item);
        }
    }
