    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ObjectUsingService> MyServiceUsers {get; set;
    }
    public class Store : ObjectUsingService
    {
        public int ServiceId {get; set;}
        public virtual Service Service { get; set; }
    }
    
    public class Store : ObjectUsingService
    {
        public int Id { get; set; }
    }
    
    //...
