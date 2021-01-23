    public class MyObject
    {
        public int Id { get; set; }
        public int IntValue { get; set; }
        public MyIdentifierType MyId
        {
            get { return new MyIdentifierType {UniqueId = Id}; } 
            set { Id = value.UniqueId; }
        }
    }
