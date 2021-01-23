    public static string ToXml<T>(this object obj)
    {
        using (var memoryStream = new MemoryStream())
        {
            using (TextWriter streamWriter = new StreamWriter(memoryStream))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(streamWriter, obj);
                return Encoding.ASCII.GetString(memoryStream.ToArray());
            }
        }
    }
    public static void ToXmlFile<T>(this object obj, string fileName)
    {
        using (TextWriter streamWriter = new StreamWriter(fileName))
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(streamWriter, obj);
        }
    }
