    interface ISomeClass
    {
        string MyProperty { get; }
    }
    class SomeClass : ISomeClass
    {
        string MyProperty { get; set; }
        public static ISomeClass Default = new SomeClass(); 
    }
