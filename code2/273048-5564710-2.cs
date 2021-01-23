    public class PageNode
    {
        public string Name { get; set; }
        public Uri URI { get; set; }
        public List<PageNode> Children { get; set; } // This should be done with a private setter, but you get that...
    }
