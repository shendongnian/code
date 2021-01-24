    public class Id
    {
        public string System_Guid { get; set; }
    }
    
    public class MainClass
    {
        public string Text { get; set; }
        public Id Id { get; set; }
    }
    
    public class rootClass
    {
        public List<MainClass> MainClass { get; set; }
    }
