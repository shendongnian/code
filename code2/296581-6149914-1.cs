    foreach (var property in properties.Where(IsNotType))
    {
    }
    
    //and farther :
    
    bool IsNotType(Property p)
    {
        return property.Name != "Type";
    }
