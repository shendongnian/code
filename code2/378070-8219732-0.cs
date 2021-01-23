    public class Item {
        public string Name { get; set; }
        [XmlElement("Item")]
        public List<Item> Children { get; set; }
    }
    public class Item {
        public string Name { get; set; }
    }
