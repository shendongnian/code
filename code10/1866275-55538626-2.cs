    public class MyClassConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyClass);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            JObject obj = JObject.Load(reader);
            // Populate the "Info" field last so it will not be overwritten
            return new MyClass
            {
                EvilField1 = (string)obj["EvilField1"],
                EvilField2 = (string)obj["EvilField2"],
                Info = (string)obj["Info"]
            };
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
