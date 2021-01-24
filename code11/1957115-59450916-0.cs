    public static class ObjectReflectionExtensions
    {
        public static  object GetValueByName<T>(this T thisObject,  string propertyName)
        {
            PropertyInfo prop = typeof(T).GetProperty(propertyName);
            return prop.GetValue(thisObject);
    
        }
    }
