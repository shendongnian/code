    public static Dictionary<string, TEnum> ToDictionary<TEnum>() where TEnum : struct, IConvertible
    {
        if (!typeof(TEnum).IsEnum)
            throw new ArgumentException("Type must be an enumeration");
    	return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().
                ToDictionary(e => Enum.GetName(typeof(TEnum), e));
    }
