    public static List<PropertyInfo> ProcessType(Type type)
    {
        return ProcessType(type, new List<Type>());
    }
    public static List<PropertyInfo> ProcessType(Type type, List<Type> processedTypes)
    {
        // Keep track of results
        var result = new List<PropertyInfo>();
        // Iterate properties of the type
        foreach (var property in type.GetProperties())
        {
            var propertyType = property.PropertyType;
            // If the property has a primitive type
            if (propertyType.IsPrimitive)
            {
                // add it to the results
                result.Add(property);
            }
            // If the property has a non-primitive type
            // and it has not been processed yet
            else if (!processedTypes.Contains(propertyType))
            {
                // Mark the property's type as already processed
                processedTypes.Add(propertyType);
                // Recursively processproperties of the property's type
                result.AddRange(ProcessType(propertyType, processedTypes));
            }
        }
        return result;
    }
