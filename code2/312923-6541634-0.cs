    /// <summary>
    /// Serializes an object to Xml as a string.
    /// </summary>
    /// <typeparam name="T">Datatype T.</typeparam>
    /// <param name="ToSerialize">Object of type T to be serialized.</param>
    /// <returns>Xml string of serialized type T object.</returns>
    public static string SerializeToXmlString<T>(T ToSerialize)
    {
        string xmlstream = String.Empty;
        using (MemoryStream memstream = new MemoryStream())
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlTextWriter xmlWriter = new XmlTextWriter(memstream, Encoding.UTF8);
            xmlSerializer.Serialize(xmlWriter, ToSerialize);
            xmlstream = UTF8ByteArrayToString(((MemoryStream)xmlWriter.BaseStream).ToArray());
        }
        return xmlstream;
    }
    /// <summary>
    /// Deserializes Xml string of type T.
    /// </summary>
    /// <typeparam name="T">Datatype T.</typeparam>
    /// <param name="XmlString">Input Xml string from which to read.</param>
    /// <returns>Returns rehydrated object of type T.</returns>
    public static T DeserializeXmlString<T>(string XmlString)
    {
        T tempObject = default(T);
        using (MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(XmlString)))
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            tempObject = (T)xs.Deserialize(memoryStream);
        }
        return tempObject;
    } 
    // Convert Array to String
    public static String UTF8ByteArrayToString(Byte[] ArrBytes)
    { return new UTF8Encoding().GetString(ArrBytes); }
    // Convert String to Array
    public static Byte[] StringToUTF8ByteArray(String XmlString)
    { return new UTF8Encoding().GetBytes(XmlString); }
