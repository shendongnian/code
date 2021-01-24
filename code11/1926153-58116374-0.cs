    public class Id
    {
        public int value { get; set; }
        public string url { get; set; }
        public string content { get; set; }
    }
    public class RootObject
    {
        public string images { get; set; }
        public List<Id> id { get; set; }
        public List<string> answers { get; set; }
        public string type { get; set; }
        public string row { get; set; }
    }
