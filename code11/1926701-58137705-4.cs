    class CollectionJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType &&
                objectType.GetGenericTypeDefinition() == typeof(CollectionResponse<>);
        }
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            // load the JSON into a JObject
            var obj = JObject.Load(reader);
            // we expect one and only one list of items; don't care what its name is
            var itemsProp = obj.Properties().Single(p => p.Value.Type == JTokenType.Array);
            // replace the existing list property with a new one called "Items"
            itemsProp.Replace(new JProperty("Items", itemsProp.Value));
            // create an instance of the CollectionResponse model
            var instance = Activator.CreateInstance(objectType);
            // populate it from the modified JObject
            serializer.Populate(obj.CreateReader(), instance);
            return instance;
        }
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
