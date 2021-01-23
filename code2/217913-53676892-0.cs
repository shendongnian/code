    public static bool IsPropertyOverridable(this PropertyInfo propertyInfo)
    {
        return (propertyInfo.IsGetPropertyVirtual() || propertyInfo.IsSetPropertyOverridable());
    }
    public static bool IsGetPropertyVirtual(this PropertyInfo propertyInfo)
    {
        if (false == propertyInfo.CanRead)
        {
            return false;
        }
        return propertyInfo.GetGetMethod(nonPublic: true).IsOverridable();
    }
    public static bool IsSetPropertyOverridable(this PropertyInfo propertyInfo)
    {
        if (false == propertyInfo.CanWrite)
        {
            return false;
        }
        return propertyInfo.GetSetMethod(nonPublic: true).IsOverridable();
    }
