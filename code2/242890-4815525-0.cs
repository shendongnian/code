    [XmlRoot(ElementName="panel")]
    public class Panel
    {
        [System.Xml.Serialization.XmlElementAttribute("tr")]
        public List<Tr> tr { get; set; }
    }
    
    public class Tr
    {
        [System.Xml.Serialization.XmlElementAttribute("td")]
        public List<Td> td { get; set; }
    }
    
    public class Td
    {
        [System.Xml.Serialization.XmlElementAttribute("element")]
        public Element Element { get; set; }
    }
    
    public class Element
    {
        [System.Xml.Serialization.XmlText]
        public string prop { get; set; }
    }
