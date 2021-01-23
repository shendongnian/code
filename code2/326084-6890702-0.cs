    public static Object[] GetStringValue(this Enum value)
    {
        // Get the type
        Type type = value.GetType();
        // Get fieldinfo for this type
        FieldInfo fieldInfo = type.GetField(value.ToString());
        // Get the stringvalue attributes
        StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
            typeof(StringValueAttribute), false) as StringValueAttribute[];
        PropertyInfo[] pi = attribs[0].GetType().GetProperties();
        Object[] Vals = new Object[pi.Length];
        int j = 0;
        foreach (PropertyInfo item in pi)
        {
             Vals[j] = item.GetValue(attribs[0],null);
            j++;
        }
        return attribs.Length > 0 ? Vals : null; // i have more values
    }
