    public object GetPropertyValue(object instance ,string propertyName)
    {
        var objType = instance.GetType();
        var prop = objType.GetProperty(propertyName);
        return prop.GetValue(instance, null);
    }
