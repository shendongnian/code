    public static string SerializeObjectToXml<T>(T obj)
    {
        MemoryStream memoryStream = new MemoryStream();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
    
        xmlSerializer.Serialize(xmlTextWriter, obj);
        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
    
        string xmlString = ByteArrayToStringUtf8(memoryStream.ToArray());
    
        xmlTextWriter.Close();
        memoryStream.Close();
        memoryStream.Dispose();
    
        return xmlString;
    }
    public static T DeserializeXmlToObject<T>(string xml)
    {
        using (MemoryStream memoryStream = new MemoryStream(StringToByteArrayUtf8(xml)))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StreamReader xmlStreamReader = new StreamReader(memoryStream, Encoding.UTF8))
            {
                return (T)xmlSerializer.Deserialize(xmlStreamReader);
            }
        }
    }
    public static string ByteArrayToStringUtf8(byte[] value)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        return encoding.GetString(value);
    }
    public static byte[] StringToByteArrayUtf8(string value)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        return encoding.GetBytes(value);
    }
