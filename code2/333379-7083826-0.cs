    /// <summary>
    /// Serialize an object into XML and save to a file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="filePath"></param>
    public static void SerializeToXml<T>(T value, string filePath) where T : class
    {
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(T));
            x.Serialize(stream, value);
        }
    }
    /// <summary>
    /// Deserialize an XML File into an object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static T DeserializeFromXml<T>(string filePath) where T : class
    {
        using (StreamReader stream = new StreamReader(filePath))
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(T));
            return (T)x.Deserialize(stream);
        }
    }
