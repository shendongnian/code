        public static MemoryStream ToMemoryStream(object entity)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, entity);
            return ms;
        }
        public static T FromMemoryStream<T>(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }
