    public static int GetPropertiesMaxLength(object obj)
    {
        int totalMaxLength=0;
        Type type = obj.GetType();
        PropertyInfo[] info = type.GetProperties();
        foreach (PropertyInfo property in info)
        {
            totalMaxLength+= property.GetValue(obj, null).ToString().Length;
        }
        return totalMaxLength;
    }
