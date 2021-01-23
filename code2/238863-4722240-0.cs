    public static TEnum ToEnum<TEnum>(this int val)
    {
        if (!typeof(System.Enum).IsAssignableFrom(typeof(TEnum)))
    throw new ArgumentException(string.Format("{0} is not Enum", typeof(TEnum).Name));
    
        return (TEnum) System.Enum.ToObject(typeof(TEnum), val);
    }
    
    
    public static TEnum ToEnum<TEnum>(this string val)
    {
        if (!typeof(System.Enum).IsAssignableFrom(typeof(TEnum)))
    throw new ArgumentException(string.Format("{0} is not Enum", typeof(TEnum).Name));
    
        return (TEnum)System.Enum.Parse(typeof(TEnum), val);
    }
