    static class SingleFlagCache<TEnum>
    {
        internal static TEnum[] values = Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Where(e => IsPowerOfTwo(Convert.ToInt64(e))).ToArray();
    }
    public static IEnumerable<TEnum> SingleFlagEnumValues<TEnum>()
        => SingleFlagCache<TEnum>.values;
