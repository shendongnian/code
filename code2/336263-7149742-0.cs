    public abstract class ReflectionHelper<T>
    {
        protected ReflectionHelper()
        { }
              
        public static string ToCsv(string delimiter = ",")
        {
            var fieldCollector = new StringBuilder();
            var type = typeof(T);
            var fields = type.GetFields();
            foreach (var f in fields)
            {
                fieldCollector.Append(f.GetValue(null) + delimiter);
            }
            return fieldCollector.ToString();
        }
    }
    public class Something : ReflectionHelper<Something>
    {
        protected Something() : base()
        {
        }
        public static string Field1 = "Some Data";
        public static string Field2 = "Persons Name";
        public static string Field3 = "3030 Plane Ave.";
    }
