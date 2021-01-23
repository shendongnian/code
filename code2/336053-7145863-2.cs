    public class MyItem
    {
        public string Name { get; set; }
        public string PartNumber { get; set; } // I did this as string rather than int
        public string Description { get; set; }
    }
    
    public List<MyItem> items = new List<MyItem>();
