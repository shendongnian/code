    public class Foo
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public int Prop3 { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo();
            // Use reflection to get all string properties 
            // that have getters and setters
            var properties = from p in typeof(Foo).GetProperties()
                             where p.PropertyType == typeof(string) &&
                                   p.CanRead &&
                                   p.CanWrite
                             select p;
            foreach (var property in properties)
            {
                var value = (string)property.GetValue(foo, null);
                if (value == null)
                {
                    property.SetValue(foo, string.Empty, null);
                }
            }
            // at this stage foo should no longer have null string properties
        }
    }
