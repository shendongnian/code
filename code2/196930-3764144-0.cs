    public typesectionEnum GetEnum(string input)
    {
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
                    return (typesectionEnum)value;
                }
            }
        }
        return (typesectionEnum)0;
    }
