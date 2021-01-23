    public static void BuildUpButSkipInitializedProperties(
        this UnityContainer container, object instance)
    {
        var registeredTypes = (
            from registration in container.Registrations
            select registration.RegisteredType)
            .ToArray();
        var injectableProperties =
            from property in instance.GetType().GetProperties()
            where property.GetGetMethod() != null
            where property.GetSetMethod() != null
            where property.GetValue(instance, null) == null
            where registeredTypes.Contains(property.PropertyType)
            select property;
            
        foreach (var property in injectableProperties)
        {
            object value = container.Resolve(property.PropertyType);
            property.SetValue(instance, value);
        }
    }
