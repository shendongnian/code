    [XmlRoot("companies")]
    public class Root
    {
        [XmlElement("company")]    
        public company[] companies;
    }
    public class company
    {
        [XmlAttribute("id")]
        public string id;
        public string code;
        public string detail;
    }
    XmlSerializer xml = new XmlSerializer(typeof(Root));
    Root r = (Root)xml.Deserialize(new StringReader(xmlstr));
