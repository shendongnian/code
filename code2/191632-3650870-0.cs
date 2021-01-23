    [XmlRootAttribute(ElementName="Root", IsNullable=false)] 
    public class RootNode 
    { 
        [XmlAttribute("Name")] 
        public string Name { get; set; } 
     
        public string SomeKey { get; set; } 
     
        [XmlElement("Element")] 
        public List<int> Elements { get; set; } 
    } 
