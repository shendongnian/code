    [XmlRoot(ElementName = "set")]
    public class Set
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "pictures")]
        public Pictures Pictures { get; set; }
    }
    
    [XmlRoot(ElementName = "pictures")]
    public class Pictures
    {
        [XmlElement(ElementName = "picture")]
        public List<SetPicture> Picture { get; set; }
    }
