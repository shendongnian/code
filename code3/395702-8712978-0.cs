    public static T Deserialize<T>(string xmlDataToDeSerialize)
    {
        XmlSerializer xmlDeSerializer = new XmlSerializer(typeof(T));
        StringReader stringReader = new StringReader(xmlDataToeSerialize);
        return (T)xmlDeSerializer.Deserialize(stringReader);            
    }
