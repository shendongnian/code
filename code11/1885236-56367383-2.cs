    public static ClassAandB Deserialize(XmlReader reader)
    {
        reader.MoveToContent();
        string rootName = reader.Name;
        var serializer  = new XmlSerializer(typeof(ClassAandB), 
            new XmlRootAttribute(rootName)
            );
        var deserialized = serializer.Deserialize(reader) as ClassAandB;
        return deserialized;
    }
