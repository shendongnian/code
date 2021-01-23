        private static string GetPropertyValue(Assembly assembly, string className, 
            string propertyName)
        {
            object instance = assembly.CreateInstance(className);
            Type classType = instance.GetType();
            MethodInfo method = classType.GetMethod("LoadFromXmlData");
            method.Invoke(instance, new object[] { classType, myData });
            PropertyInfo property = classType.GetProperty(propertyName);
            return property.GetValue(instance, null).ToString();
        }
