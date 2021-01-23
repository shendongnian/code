    public class Configuration : IXmlSerializable
    {
        [XmlAttribute]
        public string MyAttribute { get; set; }
        [XmlText]
        public string Content { get; set; }
        public void ReadXml(XmlReader reader)
        {
            if(reader.NodeType == XmlNodeType.Element &&
               string.Equals("Configuration", reader.Name, StringComparison.OrdinalIgnoreCase))
            {
                MyAttribute = reader["MyAttribute"];
            }
            if(reader.Read() &&
               reader.NodeType == XmlNodeType.Element &&
               string.Equals("SomeOtherXml", reader.Name, StringComparison.OrdinalIgnoreCase))
            {
                Content = reader.ReadOUterXml();  //Content = "<SomeOtherXml />"
            }
        }
        public void WriteXml(XmlWriter writer) { }
        public XmlSchema GetSchema() { }
    }
