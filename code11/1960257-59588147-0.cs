    public static class ObjectExtensions
    {        
        public static bool ArePropertiesNotNull<T>(this T obj)
        {
            return typeof(T).GetProperties().All(propertyInfo => propertyInfo.GetValue(obj) != null);
        }
    }
