     public static class BinaryJson
    {
        public static string SerializeToBase64String(this object obj)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            MemoryStream objBsonMemoryStream = new MemoryStream();
            using (BsonWriter bsonWriterObject = new BsonWriter(objBsonMemoryStream))
            {
                jsonSerializer.Serialize(bsonWriterObject, obj);
                return Convert.ToBase64String(objBsonMemoryStream.ToArray());
            }           
            //return Encoding.ASCII.GetString(objBsonMemoryStream.ToArray());
        }
        public static T DeserializeToObject<T>(this string base64String)
        {
            byte[] data = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(data);
            using (BsonReader reader = new BsonReader(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(reader);
            }
        }
    }
