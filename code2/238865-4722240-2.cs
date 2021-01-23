    public static TEnum ToEnum<TEnum>(this int val)
    {
        return (TEnum) System.Enum.ToObject(typeof(TEnum), val);
    }
----------
      
    public static TEnum ToEnum<TEnum>(this string val)
    {
        return (TEnum) System.Enum.Parse(typeof(TEnum), val);
    }
