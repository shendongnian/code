    public TEnum GetEnum<TEnum>(string input) where TEnum : struct
    {
        if (!typeof(TEnum).IsEnum)
            throw new Exception(typeof(TEnum).GetType() + " is not en enum");
        Type dataType = Enum.GetUnderlyingType(typeof(typesectionEnum));
        foreach (FieldInfo field in
            typeof(typesectionEnum).GetFields(BindingFlags.Static | BindingFlags.GetField |
            BindingFlags.Public))
        {
            object value = field.GetValue(null);
            foreach (DescriptionAttribute attrib in field.GetCustomAttributes(true).OfType<DescriptionAttribute>())
            {
                if (attrib.Description == input)
                {
                    return (TEnum)value;
                }
            }
        }
        return default(TEnum);
    }
