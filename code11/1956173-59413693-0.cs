    public class Thing
    {
        private Thing(string name, string something, bool hasValue, string value)
        {
            Name = name;
            Something = something;
            HasValue = hasValue;
            Value = value;
        }
        public string Name { get; }
        public string Something{ get; }
        public bool HasValue { get; }
        public string Value{ get; }
        public static Thing Thing1 = new Thing("Thing1", "Something1", true, "Value1");
        public static Thing Thing2 = new Thing("Thing2", "Something2", false, null);
    }
