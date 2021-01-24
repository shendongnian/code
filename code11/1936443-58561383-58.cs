    class CustomMetadataConverter<T> : JsonConverter where T : class
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = new JObject(
            JArray.Load(reader)
                  .Children<JObject>()
                  .Select(jo => new JProperty((string)jo["Key"], jo["Value"]))
                  );
            T result = Activator.CreateInstance<T>();
            serializer.Populate(obj.CreateReader(), result);
            return result;
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JArray array = new JArray(
            JObject.FromObject(value)
                   .Properties()
                   .Select(jp =>
                       new JObject(
                           new JProperty("Key", jp.Name),
                           new JProperty("Value", jp.Value)
                       )
					)
			);
            array.WriteTo(writer);
        }
    }
	
