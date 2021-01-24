    public class Id
    {
        public string __invalid_name__System.Guid { get; set; }
    }
    
    public class MainClass
    {
        public string Text { get; set; }
        public Id Id { get; set; }
    }
    
    public class RootObject
    {
        public List<MainClass> MainClass { get; set; }
    }
