        public static string ObjectToXML(object Object)
        {
            if (Object == null)
                throw new ArgumentException("Object can not be null");
            using (MemoryStream Stream = new MemoryStream())
            {
                XmlSerializer Serializer = new XmlSerializer(Object.GetType());
                Serializer.Serialize(Stream, Object);
                Stream.Flush();
                return UTF8Encoding.UTF8.GetString(Stream.GetBuffer(), 0, (int)Stream.Position);
            }
        }
        public static T XMLToObject<T>(string XML)
        {
            if (string.IsNullOrEmpty(XML))
                throw new ArgumentException("XML can not be null/empty");
            using (MemoryStream Stream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(XML)))
            {
                XmlSerializer Serializer = new XmlSerializer(typeof(T));
                return (T)Serializer.Deserialize(Stream);
            }
        }
