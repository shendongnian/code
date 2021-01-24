    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Person
            {
                MyProperty = " A",
                MyProperty1 = " A ",
                MyProperty2 = "A ",
                MyProperty3 = "A A A",
            };
            TrimStrings(obj);
        }
        public static void TrimStrings(object obj)
        {
            Type stringType = typeof(string);
            var properties = obj.GetType().GetProperties().Where(x => x.PropertyType == stringType);
            foreach(var property in properties)
            {
                string value = (string)property.GetValue(obj);
                property.SetValue(obj, value?.Trim());
            }
        }
    }
    
    public class Person
    {
        public string MyProperty { get; set; }
        public string MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public string MyProperty3 { get; set; }
    }
