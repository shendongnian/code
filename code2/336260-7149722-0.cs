    public static class ReflectionHelperExtensions
    {
        public static string ToCSV<T>(this T instance)
        {
            var type = typeof(T);
            var fields = type.GetFields();
            var fieldCollector = new StringBuilder();        
            foreach (FieldInfo f in fields)
            {
                fieldCollector.Append(f.GetValue(null) + ",");
            }
            return fieldCollector.ToString();
        }
    }
