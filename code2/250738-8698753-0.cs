    public static T Deserialize<T>(string input)
    {
        using (XmlReader reader = XmlReader.Create(new StringReader(input)))
        {
            DataContractSerializer formatter0 = 
                new DataContractSerializer(typeof(T));
            return (T)formatter0.ReadObject(reader);
        }
    }
