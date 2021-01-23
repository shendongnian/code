    public class ExternalClass
    {
        public string Name {get;set;}
        public InternalClass IClass{get;set;}
        public ExternalClass( int number){
            IClass = new InternalClass(){ SomeNumber = number};
        }
        public class InternalClass
        {
            public int SomeNumber {get;set}
        }
    }
