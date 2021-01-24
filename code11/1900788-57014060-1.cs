    public static IEnumerable<PropertyInfo> EnumeratePropertiesWithMyCustomAttributes(object obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException();
        }
        return EnumeratePropertiesWithMyCustomAttributes(obj.GetType());
    }
