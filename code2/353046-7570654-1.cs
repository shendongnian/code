    private static IEnumerable<DependencyProperty> GetDependencyProperties(DependencyObject o)
    {
        return from field in o.GetType().GetFields(BindingFlags.Public | 
                                                   BindingFlags.FlattenHierarchy | 
                                                   BindingFlags.Static)
               where field.FieldType == typeof(DependencyProperty)
               select (DependencyProperty)field.GetValue(null);
    }
