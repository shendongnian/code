            // Get a PropertyInfo of specific property type(T).GetProperty(....)
        PropertyInfo propertyInfo;
        propertyInfo = typeof(b)
            .GetProperty("Description", BindingFlags.Public | BindingFlags.Static| BindingFlags.FlattenHierarchy);
        // Use the PropertyInfo to retrieve the value from the type by not passing in an instance
        object value = propertyInfo.GetValue(new b(), null);
