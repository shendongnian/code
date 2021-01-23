    public class LinkDto
    {
        [XmlAttribute("url")]
        public string Url { get; set; }
    
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlAttribute("description")]
        public string Description { get; set; }
    }
    
    public class CategoryDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlElement("link")]
        public List<Link> Links { get; set; }
    }
