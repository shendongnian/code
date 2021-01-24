    public interface BaseObject
    {
        string Title { get; set; }
        string Date { get; set; }
        string id { get; set; }
        string location { get; set; }
        string Status { get; set; }
        string laterDate { get; set; }
        string hashNumber { get; set; }
        Info info { get; set; }
    }
    public class A : BaseObject
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string id { get; set; }
        public string location { get; set; }
        public string Status { get; set; }
        public string laterDate { get; set; }
        public string hashNumber { get; set; }
        public Info info { get; set; }
      // your code....
    }
    public class B
    {
        public Input Input { get; set; }
    }
    public class Input
    {
        public BaseObject Output{ get; set; }
    }
    
    public class Output : BaseObject
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string id { get; set; }
        public string location { get; set; }
        public string Status { get; set; }
        public string laterDate { get; set; }
        public string hashNumber { get; set; }
        public Info info { get; set; }
    }
