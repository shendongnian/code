    private void SetCollectionPropertyOnPoco<T>(T poco, PropertyInfo property, dynamic proxyPropertyValue) where T : class
    {
        // Create a HashSet<> with the correct type
        var genericTypeArguments = ((System.Type)(proxyPropertyValue.GetType())).GenericTypeArguments;
        var hashSetType = typeof(System.Collections.Generic.HashSet<>).MakeGenericType(genericTypeArguments);
        var hashSet = Activator.CreateInstance(hashSetType);
            
        // Iterate through each item in the collection, unproxy it, and add it to the hashset.
        foreach (var item in proxyPropertyValue)
        {
            object unproxiedValue = SafeUnproxy(item);
            hashSetType.GetMethod("Add").Invoke(hashSet, new[] { unproxiedValue }); // Add the unproxied value to the new hashset
        }
    
        property.SetValue(poco, hashSet); // Set the new hashset as the poco property value.        
    }
