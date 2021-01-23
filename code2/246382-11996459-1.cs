    public static T DeserializeXmlToObject<T>(string xml)
    {
     //Encoding.UTF8.GetBytees to Encoding.UTF8.GetBytes
        using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(memoryStream, Encoding.UTF8);
            return (T)xmlSerializer.Deserialize(reader);
        }
    }
