    public class SomeModel
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        [JsonConverter(typeof(InfoToStringConverter))]
        public string Info { get; set; }
    }
    
    public class InfoToStringConverter : JsonConverter<string>
    {
        public override string Read(
            ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                return jsonDoc.RootElement.GetRawText();
            }
        }
    
        public override void Write(
            Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
