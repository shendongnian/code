    public static XElement SerializeToXElement(object o)
    {
        var doc = new XDocument();
        using (XmlWriter writer = doc.CreateWriter())
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            serializer.Serialize(writer, o);
        }
        
        return doc.Root;
    }
