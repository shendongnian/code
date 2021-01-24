    class ServiceResponceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ServiceResponce));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray ja = JArray.Load(reader);
            ServiceResponce resp = new ServiceResponce();
   
            resp.Events = ja[1].ToObject<Event[]>(serializer);
            return resp;
        }
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
