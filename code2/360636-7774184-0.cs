    public static class PBSerializer
    {
        public static string Serialize(Type objType, object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(stream, obj);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
        // Ideally change this to use a return value instead of an out parameter...
        public static void Deserialize(string serializedObj, out test obj)
        {
            byte[] data = Convert.FromBase64String(serializedObj);
            using (MemoryStream stream = new MemoryStream(data))
            {
                obj = ProtoBuf.Serializer.Deserialize<test>(stream);
            }
        }
