    var properties = aObject.GetType().GetProperties();
    var bType = bObject.GetType();
    
    foreach (var property in properties)
    {
        var bProperty = bType.GetProperty(property.Name);
        
        bProperty.SetValue(bObject, property.GetValue(aObject, null),null);
    }
