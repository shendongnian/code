    public class RequestLogConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(RequestLog);
    
        public override bool CanWrite => false;
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
    
            // Start by running the default serialisation
            var log = new RequestLog();
            serializer.Populate(jObject.CreateReader(), log);
    
            // Manually deserialize RequestPayload
            log.RequestPayload = jObject["RequestPayload"].ToObject<RequestPayload>();
    
            return log;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
