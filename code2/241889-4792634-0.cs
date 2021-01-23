    public static bool SerializeTo<T>(T obj, string path)
    {
        XmlSerializer xs = new XmlSerializer(obj.GetType());
        using(TextWriter writer = new StreamWriter(path, false)) {
            xs.Serialize(writer, obj);
            writer.Close();
        }
        return true;
    }
