    public class VolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
    }
    
    public class Item
    {
        public VolumeInfo VolumeInfo { get; set; }
    }
    
    public class RootObject
    {
        public List<Item> Items { get; set; }
    }
