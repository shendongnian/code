    class CustomXml: IXmlSerializable
    {
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            //
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            if (SerializationParameter.FullSerialization)
               //deserialize everything
            else
               //deserialize one field only
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            if (SerializationParameter.FullSerialization)
               //serialize everything
            else
               //serialize one field only
        }
    }
