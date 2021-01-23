    public static int GetPropertiesMaxLength(object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] info = type.GetProperties();
        int totalMaxLength = info.Sum(prop => (prop.GetValue(prop, null) as string).Length);        
        return totalMaxLength;
    }
