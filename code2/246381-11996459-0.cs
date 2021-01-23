    public static T DeserializeXmlToObject<T>(string xml)
    {
        using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytees(xml)))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(memoryStream, Encoding.UTF8);
            return (T)xmlSerializer.Deserialize(reader);
        }
    }
