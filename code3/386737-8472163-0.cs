    public static class GenericSerializer
    {
        public static string Serialize<T>(ICollection<T> listToSerialize)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializer xmlSerializer;
            try
            {
                xmlSerializer = new XmlSerializer(typeof(List<T>));
                xmlSerializer.Serialize(stream, listToSerialize);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            finally
            {
                stream.Close();
            }
        }
        public static string Serialize<T>(T objectToSerialize)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializer xmlSerializer;
            try
            {
                xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stream, objectToSerialize);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            finally
            {
                stream.Close();
            }
        }
      public static T Deserialize<T>(string xmlDataToeSerialize)
        {
            XmlSerializer xmlDeSerializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(xmlDataToeSerialize);
            return (T)xmlDeSerializer.Deserialize(stringReader);            
        }
    }
