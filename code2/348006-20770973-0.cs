    public static byte[] XmlSerializeToByte<T>(T value) where T : class
    {
        if (value == null)
        {
            throw new ArgumentNullException();
        }
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (MemoryStream memoryStream = new MemoryStream())
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream))
            {
                serializer.Serialize(xmlWriter, value);
                return memoryStream.ToArray();
            }
        }
    }
