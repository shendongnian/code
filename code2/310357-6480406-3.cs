    public static void SerializeToXml(Video video, string outputXmlFilePath)
    {
        if (video== null)
        {
            throw new ArgumentNullException("video");
        }
    
        if (outputXmlFilePath == null)
        {
            throw new ArgumentNullException("outputXmlFilePath");
        }
    
        System.Xml.Serialization.XmlSerializer xmlSerializer =
                    new System.Xml.Serialization.XmlSerializer(video.GetType());
    
        using (StreamWriter streamWriter = new StreamWriter(outputXmlFilePath, false, Encoding.UTF8))
        {
            xmlSerializer.Serialize(streamWriter, value);
        }
    }
    public static Video DeserializeFromXml(string xmlFilePath)
    {
        if (xmlFilePath == null)
        {
            throw new ArgumentNullException("xmlFilePath");
        }
    
        if (!File.Exists(xmlFilePath))
        {
            throw new FileNotFoundException("file to deserialize from xml is not exists", xmlFilePath);
        }
    
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Video));
    
        Video video = null;
    
        using (StreamReader streamReader = new StreamReader(xmlFilePath, Encoding.UTF8))
        {
            deserializedObject = serializer.Deserialize(streamReader);
        }
        return video;
    }
