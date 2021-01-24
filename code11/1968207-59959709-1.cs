    public T GetPropertyValue<T>(this IYourInterface self, string name) 
    {
       var type = self.GetType();
       var property = type.GetProperty(propertyName);
       return (T) property.GetValue(self);
    }
