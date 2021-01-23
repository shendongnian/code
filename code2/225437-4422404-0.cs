    public static class MyClass
    {
        public static readonly Dictionary<string, string> Properites = new Dictionary<string, string>();
        
        public string Property1 { get {return Properties["Property1"];} }
        public string Property2 { get {return Properties["Property2"];} }
    }
