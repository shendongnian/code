    void ValidateProperty(string value)
    {
        var setter = (new StackTrace()).GetFrame(1).GetMethod();
    
        var property = 
            setter.DeclaringType
                  .GetProperties()
                  .FirstOrDefault(p => p.GetSetMethod() == setter);
    
        Debug.Assert(property != null);
    
        var attributes = property.GetCustomAttributes(typeof(TestMaxStringLengthAttribute), true);
    
        //Use the attributes to check the length, throw an exception, etc.
    }
