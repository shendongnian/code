    public class GoogleSearchItem
    {
        public string kind { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string displayLink { get; set; }
        // and so on... add more properties here if you want
        // to deserialize them
    }
    public class SourceUrl
    {
        public string type { get; set; }
        public string template { get; set; }
    }
    public class GoogleSearchResults
    {
        public string kind { get; set; }
        public SourceUrl url { get; set; }
        public GoogleSearchItem[] items { get; set; }
        // and so on... add more properties here if you want to
        // deserialize them
    }
