    public class VolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public DateTime PublishedDate { get; set; }
        // any other properties you need, add here
    }
    
    public class Item
    {
        public VolumeInfo VolumeInfo { get; set; }
    }
    
    public class RootObject
    {
        public List<Item> Items { get; set; }
    }
