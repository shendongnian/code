    Type myType = myObject.GetType();
    IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
    
    foreach (PropertyInfo prop in props)
    {
        object propValue = prop.GetValue(myObject, null);
        
        // Do something with propValue
    }
