    public object StringToProperty(string propertyName)
    {
       Type type = ClassA.GetType();
       PropertyInfo theProperty = type.GetProperty(propertyName);
       
       object propertyValue = theProperty.GetValue(yourClassAInstance, null);
       return propertyValue;
    }
