    public void Foo(object obj,string propertyName,object value) 
    { 
        //Getting type of the property og object. 
        Type type = obj.GetType().GetProperty(propertyName).PropertyType;
        if (type.IsGenericType)
            type = type.GetGenericArguments()[0];
        obj.GetType().GetProperty(propertyName).SetValue(obj, Activator.CreateInstance(type, value), null);
    } 
