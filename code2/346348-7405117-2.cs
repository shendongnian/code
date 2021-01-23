    public static void setValsRecursive(object obj, object value)
    {
        Type t = obj.GetType();
        foreach (var propInfo in t.GetProperties())
        {
            if (propInfo.PropertyType.IsClass)
            {
                object propVal = propInfo.GetValue(obj, null);
                setValsRecursive(propVal, value);
            }
            propInfo.SetValue(obj, value, null);
        }
    }   
