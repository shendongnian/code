    public static IEnumerable<PropertyInfo> EnumeratePropertiesWithMyCustomAttribute(Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException();
        }
        foreach (PropertyInfo property in type.GetProperties())
        {
            if (property.HasCustomAttribute<MyCustomAttribute>())
            {
                yield return property;
            }
            if (property.PropertyType.IsReferenceType && property.PropertyType != typeof(string)) // only search for child properties if doing so makes sense
            {
                foreach (PropertyInfo childProperty in EnumeratePropertiesWithMyCustomAttributes(property.PropertyType))
                {
                    yield return childProperty;
                }
            }
        }
    }
