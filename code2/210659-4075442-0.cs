    public void Main(){
        var containerObject = new ContainerObject();
        object propertyValue;
        object nestedPropertyValue;
        if(GetValue(containerObject, "FirstPropertyName", out propertyValue){
           bool success = GetValue(propertyValue, "NestedPropertyName", out nestedPropertyValue);
        } 
        
    }
    public bool GetValue(object currentObject, string propertyName, out object propertyValue)
    {
        // Get type of current record
        var currentObjectType = currentObject.GetType();
        PropertyInfo propertyInfo = currentObjectType.GetProperty(propertyName);
  
        propertyValue = propertyInfo != null 
                        ?  propertyInfo.GetValue(currentObject,null)
                        :  null;
        return propertyValue == null;
    }
