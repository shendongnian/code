    public static IEnumerable<PropertyInfo> GetAllProperties(Type t)
    {
      if (t == null)
        return Enumerable.Empty<PropertyInfo>();
    
      BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;
        return t.GetProperties(flags).Union(GetAllProperties(t.BaseType));
    }
    
