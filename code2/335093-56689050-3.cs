    public class BinarySerializationService
        : IBinarySerializationService
    {
        public byte[] ToBytes(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            using (var memoryStream = new MemoryStream())
            {
                Serializer.Serialize(memoryStream, obj);
                var bytes = memoryStream.ToArray();
                return bytes;
            }
        }
    
        public TType FromBytes<TType>(byte[] bytes)
            where TType : class
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            var type = typeof(TType);
            var result = FromBytes(bytes, type);
            return (TType)result;
        }
    
        public object FromBytes(byte[] bytes, Type type)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            int length = bytes.Length;
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(bytes, 0, length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                var obj = Serializer.Deserialize(type, memoryStream);
                return obj;
            }
        }
    }
