    public static byte[] ConvertToBytes(object obj)
    {
        using (var ms = new MemoryStream())
        {
            using (var writer = new BsonWriter(ms))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(writer, new { Value = obj });
                return ms.ToArray();
            }
        }
    }
