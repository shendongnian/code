    public static bool IsAssignable<T>(PropertyInfo property, T value)
    {        
        if (value != null)
        {
            return property.PropertyType.IsAssignableFrom(value.GetType());
        }
        return property.PropertyType.IsAssignableFrom(typeof(T));
    }
