    /// <summary>
    /// Get the description for the enum
    /// </summary>
    /// <param name="value">Value to check</param>
    /// <returns>The description</returns>
    public static string GetDescription(object value)
    {
        Type type = value.GetType();
        string name = Enum.GetName(type, value);
        if (name != null)
        {
            FieldInfo field = type.GetField(name);
            if (field != null)
            {
                DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    string desc = attr.Description;
                    return desc;
                }
            }
        }
        return value.ToString();
    }
