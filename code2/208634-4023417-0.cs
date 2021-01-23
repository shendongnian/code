    public class ExternalClass
    {
        public string Name {get;set;}
        public InternalClass IClass{get;set;}
        public class InternalClass
        {
            public int SomeNumber {get;set}
        }
    }
