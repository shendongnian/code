    public class Mode
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<string> Channels { get; set; }
    }
    
    public class RootObject
    {
        public List<Mode> Modes { get; set; }
    }
