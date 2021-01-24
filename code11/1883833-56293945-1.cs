    public class Entry
    {
        public string type { get; set; }
        public string name { get; set; }
        public List<string> entries { get; set; }
    }
    
    public class MainProperty
    {
        public List<Entry> entries { get; set; }
    }
    
    public class RootObject
    {
        public List<MainProperty> mainProperty { get; set; }
    }
