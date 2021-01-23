    public static class SerializerDeserializerExtensions
    {
        public static byte[] Serializer(this object _object)
        {   
            byte[] bytes;
            IFormatter _BinaryFormatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                _BinaryFormatter.Serialize(stream, _object);
                bytes = stream.ToArray();
            }
            return bytes;
        }
        public static T Deserializer<T>(this byte[] _byteArray)
        {   
            T ReturnValue;
            using (var _MemoryStream = new MemoryStream(_byteArray))
            {
                BinaryFormatter _BinaryFormatter = new BinaryFormatter();
                ReturnValue = (T)_BinaryFormatter.Deserialize(_MemoryStream);    
            }
            return ReturnValue;
        }
    }   
