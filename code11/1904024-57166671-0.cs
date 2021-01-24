    public class ArchetypeConverter : JsonConverter
    { 
        public override bool CanConvert(Type objectType)
        {
            return typeof(Archetype).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var token = obj.SelectToken("standard_ccp_signature_core.components");
            if (token != null)
                obj.Add(token.Parent);
            using (reader = obj.CreateReader())
            {
                existingValue = (existingValue ?? new Archetype());
                serializer.Populate(reader, existingValue);
            }
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
