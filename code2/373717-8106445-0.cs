    public class SYMBOL
    {
        [XmlAttribute("Code")]            
        public string Code { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
    XmlSerializer xml = new XmlSerializer(typeof(SYMBOL[]));
    SYMBOL[] symbols = (SYMBOL[])xml.Deserialize(aFileStream);
