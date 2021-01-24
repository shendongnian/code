    public void MyMethod(string otherParam, object someObject) 
    {
        var prop = someObject.GetType().GetProperty("cigarettes");
    	var enumType = prop.PropertyType;
    	prop.SetValue(someObject, Enum.Parse(enumType, "yes"), null);
    }
