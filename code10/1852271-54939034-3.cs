    public class RootClass
    {
        public List<MainClass> MainClass { get; set; }
    }
    
    public class MainClass
    {
        public string Text { get; set; }
        public _Guid Id { get; set; }
    }
    
    public class _Guid
    {
        [JsonProperty("System.Guid")]
        public Guid Id { get; set; }
    }
