    public static Dictionary<string, TEnum> ToDictionary<TEnum>() where T : struct
    {
    	return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().
                ToDictionary(e => Enum.GetName(typeof(TEnum), e));
    }
