    public object GetPropertyValue(string propertyName)
    {
    //returns value of property Name
    return this.GetType().GetProperty(propertyName).GetValue(this, null);
    } 
