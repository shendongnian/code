    object classObject;
    PropertyInfo[] propertyInfos;
    propertyInfos = typeof(classObject).GetProperties(BindingFlags.Public | BindingFlags.Static);
    foreach (PropertyInfo propertyInfo in propertyInfos)
    {
         propertyInfo.SetValue(classObject, value, null)
    }
