    public void ReadXml(XmlReader reader)
    {
        reader.ReadStartElement("RootElement");
        do
        {
            if (reader.Name == "SomeNonSerializableClass")
            {
                // Perform custom serialization
            }
            else if (reader.Name == "SomeSerializableClass")
            {
                reader.ReadStartElement();
                var serializer = new XmlSerializer(typeof(SomeSerializableClass));
                serializer.Deserialize(reader.ReadSubtree());
                reader.ReadEndElement();
            }
        }
        while (reader.Name != "RootElement");
        reader.ReadEndElement();
    }
