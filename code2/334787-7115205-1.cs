    public void ReadXml(XmlReader reader)
    {
        reader.ReadStartElement("SomeClass");
        do
        {
            if (reader.Name == "ClassB")
            {
                reader.ReadStartElement();
                // manually deserialize SomeNonSerializableClass here
                reader.ReadEndElement();
            }
            else if (reader.Name == "ClassA")
            {
                reader.ReadStartElement();
                var serializer = new XmlSerializer(typeof(SomeSerializableClass));
                ClassA = (SomeSerializableClass)serializer.Deserialize(reader);
                reader.ReadEndElement();
            }
        }
        while (reader.Name != "SomeClass");
        reader.ReadEndElement();
    }
    public void WriteXml(XmlWriter writer)
    {
        writer.WriteStartElement("ClassB");
        // manually serialize SomeNonSerializableClass here
        writer.WriteEndElement();
        writer.WriteStartElement("ClassA");
        var serializer = new XmlSerializer(typeof(SomeSerializableClass));
        serializer.Serialize(writer, ClassA);
        writer.WriteEndElement();
    }
