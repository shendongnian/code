    public static Object[] GetStringValue(this Enum value)
    {
        // Get the type
        Type type = value.GetType();
        // Get fieldinfo for this type
        FieldInfo fieldInfo = type.GetField(value.ToString());
        // Get the stringvalue attributes
        StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
            typeof(StringValueAttribute), false) as StringValueAttribute[];
        
        return attribs[0].GetType().GetProperties()
            .Select(p => p.GetValue(attribs[0],null))
            .ToArray();
    }
