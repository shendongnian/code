    // Gets the attributes for the property.
    AttributeCollection attributes = propertyDescriptor.Attributes;
    
    //Checks to see if the value of the IsCustomPropertyAttribute is Yes.
    IsCustomPropertyAttribute myAttribute = 
    (IsCustomPropertyAttribute)attributes[typeof(IsCustomPropertyAttribute)];
    
    //Check if current property is CustomProperty or not
    if (myAttribute.IsCustomProperty == true)
    {
        AddProperty(propertyDescriptor);
    }
