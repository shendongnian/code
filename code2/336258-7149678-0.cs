    public static class ReflectionHelper
    {
        public static string ToCSV<T>()
        {
            StringBuilder fieldCollector = new StringBuilder();
    
            Type type = typeof(T);
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo f in fields)
            {
                fieldCollector.Append(f.GetValue(null) + ",");
            }
    
            return fieldCollector.ToString();
        }
    }
