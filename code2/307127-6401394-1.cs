    public static void SerializeToSoap<T>(this Stream target, T source)
    {
        XmlTypeMapping xmlTypeMapping = (new SoapReflectionImporter().ImportTypeMapping(typeof(T)));
        XmlSerializer xmlSerializer = new XmlSerializer(xmlTypeMapping);
        using (var xmlWriter = new XmlTextWriter(target, Encoding.UTF8))
        {
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("root");
            xmlSerializer.Serialize(xmlWriter, source);
            xmlWriter.WriteFullEndElement();
        }
    }
