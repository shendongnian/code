    readonly Type ignoreOnUnproxyAttributeType = typeof(IgnoreOnUnproxyAttribute);
    readonly string genericCollectionTypeName = typeof(ICollection<>).Name;
    
    public T UnProxy<T>(T proxyObject) where T : class
    {
        // Remember the proxyCreationEnabled value 
        var proxyCreationEnabled = Configuration.ProxyCreationEnabled;
                    
        try
        {
            Configuration.ProxyCreationEnabled = false;
            T poco = Entry(proxyObject).CurrentValues.ToObject() as T; // Convert the proxy object to a POCO object. This only populates scalar values and such, so we have to load other properties separately.
    
            // Iterate through all properties in the POCO type
            foreach (var property in poco.GetType().GetProperties())  
            {
                // To prevent cycles, like when a child instance refers to its parent and the parent refers to its child, we'll ignore any properties decorated with a custom IgnoreOnUnproxyAttribute.
                if (Attribute.IsDefined(property, ignoreOnUnproxyAttributeType))
                {
                    property.SetValue(poco, null);
                    continue;
                }
                                    
                dynamic proxyPropertyValue = property.GetValue(proxyObject); // Get the property's value from the proxy object
    
                if (proxyPropertyValue != null)
                {
                    // If the property is a collection, get each item in the collection and set the value of the property to a new collection containing those items.
                    if (property.PropertyType.IsGenericType && property.PropertyType.Name == genericCollectionTypeName)
                    {                            
                        SetCollectionPropertyOnPoco<T>(poco, property, proxyPropertyValue);
                    }
                    else
                    {
                        // If the property is not a collection, just set the value of the POCO object to the unproxied (if necessary) value of the proxy object's property.
                        if (proxyPropertyValue != null)
                        {
                            // If the type of the property is one of the types in your model, the value needs to be unproxied first. Otherwise, just set the value as is.
                            var unproxiedValue = (ModelTypeNames.Contains(property.PropertyType.Name)) ? SafeUnproxy(proxyPropertyValue) : proxyPropertyValue;
                            property.SetValue(poco, unproxiedValue);
                        }
                    } 
                }
            }
    
            return poco; // Return the unproxied object
        }
        finally
        {
            // Zet ProxyCreationEnabled weer terug naar de oorspronkelijke waarde.
            Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
    }
