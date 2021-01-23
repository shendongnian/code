    public static object DeserializeFromXElement(XElement element, Type t)
    {
        using (XmlReader reader = element.CreateReader())
        {
            XmlSerializer serializer = new XmlSerializer(t);
            return serializer.Deserialize(reader);
        }
    }
