    public static class Utility
    {
        static T GetDynamicValue<T>(this Object obj, string propertyName)
        {
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var prop = obj.GetType().GetProperty(propertyName, flags);
            var val =prop.GetValue(obj);
            return (T)val;
        }
    }
