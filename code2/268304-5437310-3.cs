    private static string GetPropertyValue(Assembly assembly, string className,     
       string propertyName)
    {
            dynamic instance = assembly.CreateInstance(className);
            Type classType = instance.GetType();
            instance.LoadFromXmlData(classType, "<xml></xml>");
            PropertyInfo property = classType.GetProperty(propertyName);
            return property.GetValue(instance, null).ToString();
    }
