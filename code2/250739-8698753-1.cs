    public static T Deserialize<T>(string rawXml)
    {
        using (XmlReader reader = XmlReader.Create(new StringReader(rawXml)))
        {
            DataContractSerializer formatter0 = 
                new DataContractSerializer(typeof(T));
            return (T)formatter0.ReadObject(reader);
        }
    }
