    [XmlRoot("My_Root", Namespace = "")]
    ARequest : IXmlSerializable
    {
        public string PropertyA { get; set; }
    
            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return (null);
            }
    
            public void ReadXml(System.Xml.XmlReader reader)
            {
                if (!reader.IsEmptyElement)
                {
                    reader.ReadStartElement();
                    PropertyA = reader.ReadElementString("PropertyA");
                    reader.ReadEndElement();
                }
            }
    
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                writer.WriteElementString("PropertyA", PropertyA);
             
            }
    
    }
