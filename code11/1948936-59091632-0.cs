       [XmlRoot(ElementName = "fruit_types")]
    public class Fruit_types
    {
        [XmlElement(ElementName = "fruit")]
        public List<string> Fruit { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "excluded_fruits")]
        public Excluded_fruits Excluded_fruits { get; set; }
    }
    [XmlRoot(ElementName = "Fruit_group")]
    public class Fruit_group
    {
        [XmlElement(ElementName = "fruit_types")]
        public Fruit_types Fruit_types { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
    [XmlRoot(ElementName = "excluded_fruits")]
    public class Excluded_fruits
    {
        [XmlElement(ElementName = "fruit")]
        public List<string> Fruit { get; set; }
    }
    [XmlRoot(ElementName = "Fruit")]
    public class Fruit
    {
        [XmlElement(ElementName = "Fruit_group")]
        public List<Fruit_group> Fruit_group { get; set; }
    }
