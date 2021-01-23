    public class Item
    {
        [XmlElement("shortDesc", Order=2)]
        public string ShortDesc { get; set; }
        private readonly List<string> categories = new List<string>();
        [XmlArray("categories", Order = 3), XmlArrayItem("category")]
        public List<string> Categories { get { return categories; } }
        [XmlElement("sub-type", Order = 1)]
        public string SubType { get; set; }
    }
