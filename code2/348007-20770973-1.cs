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
        public static T XmlDeserializeFromBytes<T> (byte[] bytes)
                                         where T : class
        {
            if (bytes == null || bytes.Length == 0)
            {
                throw new InvalidOperationException();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                using (XmlReader xmlReader = XmlReader.Create(memoryStream))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }
            //Serialize
            Duck duck = new Duck() { Name = "Donald Duck" };
            byte[] bytes = Test.XmlSerializeToByte(duck);
            //Deserialize
            var deDuck = Test.XmlDeserializeFromBytes<Duck>(bytes);
            Console.WriteLine(deDuck.Name);
