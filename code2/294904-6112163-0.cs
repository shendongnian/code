    public static bool SerializeTo<T>(T obj, string path)
    {
        XmlSerializer xs = new XmlSerializer(obj.GetType());
        using (TextWriter writer = new StreamWriter(path, false))
        {
            xs.Serialize(writer, obj);
        }
        return true;
    }
    public static T DeserializeFrom<T>(string path)
    {
        XmlSerializer xs = new XmlSerializer(typeof(T));
        using (TextReader reader = new System.IO.StreamReader(path))
        {
            return (T)xs.Deserialize(reader);
        }
    }
