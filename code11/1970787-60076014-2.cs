    [XmlRoot(ElementName = "set")]
    public class Set
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }
        [XmlArray("pictures")]
        [XmlArrayItem("picture", typeof(SetPicture))]
        public List<SetPicture> Pictures { get; set; }
    }
