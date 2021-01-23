    public static TEnum NextEnum<TEnum>(TEnum value)
    {
        if (!typeof(TEnum).IsEnum)
            throw new ArgumentException("Expected type of System.Enum", "value");
        var values = Enum.GetValues(typeof (TEnum));
        var index = Array.IndexOf(values, value);
        return (TEnum)Enum.ToObject(typeof (TEnum), values.GetValue((index + 1) % values.Length));
    }
