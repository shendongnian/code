    public class MyClass
    {
        public int ID {get;set;}
        public DateTime Created{get;set;}
        [Write(false)]
        public DateTime CreatedDate =>Created.Date;
    }
