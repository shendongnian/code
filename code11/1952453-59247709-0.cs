    public IEnumerable<TEnum> SingleFlagEnumValues<TEnum>()
    {
        return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Where(e => IsPowerOfTwo(Convert.ToInt64(e)));
    }
