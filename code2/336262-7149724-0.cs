    public static class ReflectionExtensions
    {
         public static string ToCSV(this object input)
         { 
             StringBuilder fieldCollector = new StringBuilder();
             Type type = input.GetType();
             FieldInfo[] fields = type.GetFields();
             foreach (FieldInfo f in fields)
             {
                 fieldCollector.Append(f.GetValue(null) + ",");
             }
             return fieldCollector.ToString();
        }
    }
