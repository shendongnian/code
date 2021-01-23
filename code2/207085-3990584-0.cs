    public static T DeserializeObject<T>(string filename)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var reader = XmlReader.Create(filename))
        {
            return (T)serializer.Deserialize(reader);
        }
    }
