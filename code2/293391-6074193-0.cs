    public static T GetDefaultValue<T, TParent>(string propertyName)
    {
        var property = typeof(TParent).GetProperty(propertyName);
    
        var attribute = property
            .GetCustomAttribute(typeof(DefaultValueAttribute)) 
                as DefaultValueAttribute;
    
        if(attribute != null)
        {
            return (T)attribute.Value;
        }
    }
