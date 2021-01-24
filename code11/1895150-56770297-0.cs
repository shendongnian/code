    public class MyResponse
    {
        public string resourceId {get;set;}
        public List<MyProperty> property {get;set;}
    }
    
    public class MyProperty
    {
        public string name {get;set;}
        public string value {get;set;}
    }
