    public class Id
    {
        public string MyGuid { get; set; }
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
