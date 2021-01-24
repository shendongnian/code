    public static class ReflectionExtensions
    {
        public static void SetValueIfNotNull<T>(this PropertyInfo prop, object obj, T? maybe)
            where T : struct
        {
            if (maybe.HasValue)
                prop.SetValue(obj, maybe.Value);
        }
    }
