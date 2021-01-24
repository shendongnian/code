    public class RootClass
    {
        public List<MainClass> MainClass { get; set; }
    }
    
    public class MainClass
    {
        public string Text { get; set; }
        public Guid Id { get; set; }       //<= The type "System.Guid" as it is
    }
    
