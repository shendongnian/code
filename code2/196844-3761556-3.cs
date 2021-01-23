    class CustomType
    {
        public int Integer { get; set; }
        public double Double { get; set; }
        public bool Boolean { get; set; }
        public string String { get; set; }
        
        public override string ToString()
        {
            return string.Format("int: {0}, double: {1}, bool: {2}, string: {3}", Integer, Double, Boolean, String);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var mapper = new InputMapper<CustomType>();
            
            mapper.Map("10", x => x.Integer, "Unable to set Integer property.");
            mapper.Map("32.5", x => x.Double, "Unabled to set Double property.");
            mapper.Map("True", x => x.Boolean, "Unable to set Boolean property.");
            mapper.Map("Hello world!", x => x.String, "Unable to set String property.");
            
            var customObject = mapper.Create();
            
            Console.WriteLine(customObject);
            
            Console.ReadKey();
        }
    }
