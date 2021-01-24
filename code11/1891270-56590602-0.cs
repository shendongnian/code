    public static Dictionary<TEnum, string> BuildEnumToStringMapping<TEnum>()
        where TEnum: struct
    {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum is not an enum.");
            }
            return Enum.GetValues(typeof(TEnum))
                .OfType<TEnum>()
                .ToDictionary(e => e, e => e.ToString().ToLower());
    }
