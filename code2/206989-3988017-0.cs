    public static class ExtensionMethods
    {
        public static T GetObject<T>(this T obj, T def)
        {
            if (default(T).Equals(obj))
                return def;
            else
                return obj;
        }
    }
