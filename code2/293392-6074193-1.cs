    public static T GetDefaultValue<T>(string propertyName)
    {
        var property = typeof(MyClass).GetProperty(propertyName);
    
        var attribute = property
            .GetCustomAttribute(typeof(DefaultValueAttribute)) 
                as DefaultValueAttribute;
    
        if(attribute != null)
        {
            return (T)attribute.Value;
        }
    }
