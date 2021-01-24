    Type targetType = obj.GetType();
    foreach (var propertyInfo in targetType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy))
    {
        var isetInterface = propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(ISet<>)
            ? propertyInfo.PropertyType
            : null;
        if(isetInterface == null)
        {
            isetInterface = propertyInfo.PropertyType
                .GetInterfaces()
                .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ISet<>));
        }
        if (isetInterface != null)
        {
            object isetPropertyValue = propertyInfo.GetValue(obj);
            var countPropertyInfo = isetInterface
                .GetInterfaces()
                .First(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>))
                .GetProperty("Count");
            if (isetPropertyValue == null)
            {
                Console.WriteLine($".{propertyInfo.Name} == null");
            }
            else
            {
                var count = countPropertyInfo.GetValue(isetPropertyValue);
                Console.WriteLine($".{propertyInfo.Name}.Count == {count}");
            }
        }
    }
