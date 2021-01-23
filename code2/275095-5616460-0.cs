    public static IEnumerable<DependencyProperty> GetDependencyProperties(DependencyObject owner)
    {
        var type = owner.GetType();
        var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
        return type.GetFields(flags)
                   .Where(fi => fi.FieldType == typeof(DependencyProperty))
                   .Select(fi => fi.GetValue(owner))
                   .Cast<DependencyProperty>();
    }
