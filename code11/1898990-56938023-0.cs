    [XmlRoot("item")]
    public class Item
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
    [XmlRoot(ElementName = "thing")]
    public class Thing
    {
        [XmlArray("items")]
        public Item[] Items { get; set; }
    }
