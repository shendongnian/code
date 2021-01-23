    public static bool IsAssignable(PropertyInfo property, object value)
    {
        if (value == null && property.PropertyType.IsValueType && Nullable.GetUnderlyingType(property.PropertyType) == null)
            return false;
        if (value != null && !property.PropertyType.IsAssignableFrom(value.GetType()))
            return false;
        return true;
    }
