    public class ProfessionConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IProfession);
        }
        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException("Use default serialization.");
        }
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var profession = default(IProfession);
            switch (jsonObject["JobTitle"].Value())
            {
                case "Software Developer":
                    profession = new Programming();
                    break;
                case "Copywriter":
                    profession = new Writing();
                    break;
            }
            serializer.Populate(jsonObject.CreateReader(), profession);
            return profession;
        }
    }
