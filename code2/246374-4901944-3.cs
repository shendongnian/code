    /// <summary>
    /// Serializes an object to a XML string.
    /// </summary>
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
    /// <summary>
    /// Reconstructs an object from a serialized XML string.
    /// </summary>
    public static T DeserializeXmlToObject<T>(string xml)
    {
        using (MemoryStream memoryStream = new MemoryStream(StringToByteArrayUtf8(xml)))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
    
            return (T)xmlSerializer.Deserialize(xmlTextWriter.BaseStream);
        }
    }
    /// <summary>
    /// Converts a byte array of unicode values (UTF-8 enabled) to a string.
    /// </summary>
    public static string ByteArrayToStringUtf8(byte[] value)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        return encoding.GetString(value);
    }
    /// <summary>
    /// Converts a string to a UTF-8 byte array.
    /// </summary>
    public static byte[] StringToByteArrayUtf8(string value)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        return encoding.GetBytes(value);
    }
