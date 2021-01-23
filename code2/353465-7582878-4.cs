    static IEnumerable<FieldInfo> GetDependencyProperties(Type type)
    {
        var properties = type.GetFields(BindingFlags.Static | BindingFlags.Public)
                             .Where(f=>f.FieldType == typeof(DependencyProperty));
        if (type.BaseType != null)
            properties = properties.Union(GetDependencyProperties(type.BaseType));
        return properties;
    }
