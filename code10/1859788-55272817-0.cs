    public static void RemoveSecretData(object obj)
    {
        // Retrieve all public instance properties defined for the object's type and marked with [DontSendInPublicApi]
        var propertiesToHide = obj.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.GetCustomAttribute<DontSendInPublicApiAttribute>() != null);
        foreach (var prop in propertiesToHide)
        {
            // Set all of these properties in the given object to their default values.
            // VALUE TYPES (ints, chars, doubles, etc.) will be set to default(TheTypeOfValue), by calling Activator.CreateInstance(TheTypeOfValue).
            // REFERENCE TYPES will simply be set to null.
            var propertyType = prop.PropertyType;
            if (propertyType.IsValueType)
                prop.SetValue(obj, Activator.CreateInstance(prop.PropertyType));
            else
                prop.SetValue(obj, null);
        }
    }
