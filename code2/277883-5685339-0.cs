    Type propertyType = property.PropertyType;
    if(propertyType.IsGeneric && propertyType.GetGenericTypeDefinition() == typeof(List<>))
    {
        Type argType = propertyType.GetGenericArguments()[0];
        // argType will give you your OrderDetail
    }
