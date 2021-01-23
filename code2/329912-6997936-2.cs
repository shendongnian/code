    abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        protected abstract Type GetType(Type objectType, JObject jObject);
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, 
            object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            Type targetType = GetType(objectType, jObject);
            // TODO: Change this to the Json.Net-built-in way of creating instances
            object target = Activator.CreateInstance(targetType);
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
    }
