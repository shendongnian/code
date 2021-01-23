    public class ExternalClass
    {
        public class InternalClass
        {
            public int SomeNumber {get;set}
        }
    
        public ExternalClass()
        {
            Internal = new InternalClass();
        }
    
        public string Name { get; set; }
        public InternalClass Internal { get; private set; }
    }
