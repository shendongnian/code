    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
    }
    
    static void SetValue(Object p, string propertyName, Object value)
    {
        p.GetType().GetProperty(propertyName).SetValue(p, value);
    }
    static void Main(string[] args)
    {
        var p = new Product();
        SetValue(p, "Code", "A");
        Console.WriteLine(p.Code);
            
        Console.Read();
    }
    
