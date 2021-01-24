    class Program
    {
        static void Main(string[] args)
        {
            var a = new A()
            {
                A1 = new A1Type() { B1 = "A1Type B1 prop value", B2 = "A1Type B2 prop value" },
                A2 = new A2Type() { B1 = "A2type B1 prop value", B2 = "A2Type B2 prop value" },
                A3 = new A3Type() { B1 = "A3Type B1 prop value", B2 = "A3Type B2 prop value" }
            };
            ListPropertyValuesOf("A1Type", a);
            ListPropertyValuesOf("A2Type", a);
            ListPropertyValuesOf("A3Type", a);
        }
    
        static void ListPropertyValuesOf(string propName, A classA)
        {
            // get all properties of classA object
            var props = classA.GetType().GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType.Name == propName)
                {
                    // get the specific sub-type object on classA
                    var subClassA = classA.GetType().GetProperty(prop.Name).GetValue(classA);
                      
                    // loop each of the properties on subClassA and write its value
                    foreach (var subProp in subClassA.GetType().GetProperties())
                        Console.WriteLine(subProp.GetValue(subClassA));
                }
            }
        }
    }
    
    public class A
    {
        public A1Type A1 { get; set; }
        public A2Type A2 { get; set; }
        public A3Type A3 { get; set; }
    }
    public class A1Type
    {
        public string B1 { get; set; }
        public string B2 { get; set; }
    }
    
    public class A2Type
    {
        public string B1 { get; set; }
        public string B2 { get; set; }
    }
    
    public class A3Type
    {
        public string B1 { get; set; }
        public string B2 { get; set; }
    }
