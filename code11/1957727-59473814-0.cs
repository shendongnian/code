    public static class ReflectionExtensions
    {
        public static void SetValueIfNotNull<T>(this PropertyInfo propertyInfo,
            object obj, Nullable<T> nullable)
            where T : struct
        {
            if (nullable.HasValue)
                propertyInfo.SetValue(obj, nullable.Value);
        }
    }
