    public object GetPropertyValue(string propertyName)
    {
    //returns value of property Name
    this.GetType().GetProperty(propertyName).GetValue(this, null);
    } 
