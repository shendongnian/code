    public static int GetEnumFromDescription(string description, Type enumType)
    {
        foreach (var field in enumType.GetFields())
        {
            DescriptionAttribute attribute
                = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))as DescriptionAttribute;
            if(attribute == null)
                continue;
            if(attribute.Description == description)
            {
                return (int) field.GetValue(null);
            }
        }
        return 0;
    }
