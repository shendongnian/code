    public enum Properties
    {
        A,
        B
    }
    public class Test
    {
        public string A { get; set; }
        public int B { get; set; }
    }
    static void Main()
    {
        var test = new Test() { A = "A value", B = 100 };
        var lookup = new Dictionary<Properties, System.Reflection.PropertyInfo>();
        var properties = typeof(Test).GetProperties().ToList();
        foreach (var property in properties)
        {
            Properties propertyKey;
            if (Enum.TryParse(property.Name, out propertyKey))
            {
                lookup.Add(propertyKey, property);
            }
        }
        Console.WriteLine("A is " + lookup[Properties.A].GetValue(test, null));
        Console.WriteLine("B is " + lookup[Properties.B].GetValue(test, null));
    }
