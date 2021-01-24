    /// <summary>
    /// Handles the (de)serialization of <see cref="Stream"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="Stream"/> will be written as a Base64 encoded string, on the inverse it will be converted from a Base64 string to a <see cref="MemoryStream"/>.
    /// </remarks>
    public class StreamStringConverter : JsonConverter
    {
        private static Type AllowedType = typeof(Stream);
        public override bool CanConvert(Type objectType)
            => objectType == AllowedType;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var objectContents = (string)reader.Value;
            var base64Decoded = Convert.FromBase64String(objectContents);
            var memoryStream = new MemoryStream(base64Decoded);
            return memoryStream;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var valueStream = (FileStream)value;
            var fileBytes = new byte[valueStream.Length];
            valueStream.Read(fileBytes, 0, (int)valueStream.Length);
            var bytesAsString = Convert.ToBase64String(fileBytes);
            writer.WriteValue(bytesAsString);
        }
    }
