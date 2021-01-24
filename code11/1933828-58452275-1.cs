    public partial class JsonItem
    {
        public long Id { get; set; }
        // Other props...
        public string[] Images { get; set; }
        public string[] Plan { get; set; }
        public Dictionary<string, ListAttribute> ListAttributes { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Url { get; set; }
    }
    
    public partial class ListAttribute
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Value { get; set; }
    }
