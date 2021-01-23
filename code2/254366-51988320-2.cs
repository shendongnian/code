    /// <summary>
    /// Returns a dictionary of all the Enum fields with the attribute.
    /// </summary>
    public static Dictionary<Enum, RAttribute> GetEnumObjReference<TEnum, RAttribute>()
    {
        Dictionary<Enum, RAttribute> _dict = new Dictionary<Enum, RAttribute>();
        Type enumType = typeof(TEnum);
        Type enumUnderlyingType = Enum.GetUnderlyingType(enumType);
        Array enumValues = Enum.GetValues(enumType);
        foreach (Enum enumValue in enumValues)
        {
            _dict.Add(enumValue, GetAttribute<RAttribute>(enumValue));
        }
        return _dict;
    }
