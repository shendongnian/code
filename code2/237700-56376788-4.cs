    /// <summary>
    /// Sets the Browsable attribute value of a property of a non premitive type.
    /// NOTE: The class property must be decorated with [Browsable(...)] attribute.
    /// </summary>
    /// <param name="type">The type that contains the property, of which the Browsable attribute value needs to be changed</param>
    /// <param name="propertyName">Name of the type property, of which the Browsable attribute value needs to be changed</param>
    /// <param name="isBrowsable">The new Browsable value</param>
    public static void SetBrowsableAttributeOfAProperty(Type type, string propertyName, bool isBrowsable)
    {
        //Validate type - disallow primitive types (this will eliminate problem-2 as mentioned above)
        if (type.IsEnum || BuiltInTypes.Contains(type))
            throw new Exception($"The type '{type.Name}' is not supported");
    
        var objPropertyInfo = TypeDescriptor.GetProperties(type);
    
        // Get the Descriptor's Properties
        PropertyDescriptor theDescriptor = objPropertyInfo[propertyName];
    
        if (theDescriptor == null)
            throw new Exception($"The property '{propertyName}' is not found in the Type '{type}'");
    
        // Get the Descriptor's "Browsable" Attribute
        BrowsableAttribute theDescriptorBrowsableAttribute = (BrowsableAttribute)theDescriptor.Attributes[typeof(BrowsableAttribute)];
        FieldInfo browsablility = theDescriptorBrowsableAttribute.GetType().GetField("Browsable", BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);
    
        // Set the Descriptor's "Browsable" Attribute
        browsablility.SetValue(theDescriptorBrowsableAttribute, isBrowsable);
    }
