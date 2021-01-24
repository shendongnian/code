    var type = typeof(Class2);
    var list = new List<PropertyInfo>();
    list.AddRange(type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly));
    var baseType = type.BaseType;
    if (baseType != null)
    {
        foreach (var propertyInfo in baseType.GetProperties())
        {
            if (list.All(p => p.Name != propertyInfo.Name))
                list.Add(propertyInfo);
        }
    }
    
