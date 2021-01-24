    public class Daraz
    {
        public string name { get; set; }
        public string url { get; set; }
        public string price { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
    }
    public class Items
    {
        public List<Daraz> Item { get; set; }
    }
