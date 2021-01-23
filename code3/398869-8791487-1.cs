    public class Item
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    }
    
    public class DeviceList : IXmlSerializable
    {
        public string Type { get; set; }
    
        public List<Item> Items { get; set; } 
    
    
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToContent();
        }
    
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("type", Type);
    
    
            XmlSerializer serializer = new XmlSerializer(typeof(Item));
            foreach (var item in Items)
            {
                serializer.Serialize(writer, item);
            }
        }
    }
