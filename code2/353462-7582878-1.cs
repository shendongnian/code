    static IEnumerable<FieldInfo> GetDependencyProperties(Type type)
    {
        var dependencyProperties = type.GetFields(BindingFlags.Static | BindingFlags.Public)
                                       .Where(p => p.FieldType.Equals(typeof(DependencyProperty)));
        return dependencyProperties;
    }
