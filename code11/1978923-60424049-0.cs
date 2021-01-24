    class ParentCollectionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ParentCollection);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ParentCollection pc = new ParentCollection();
            JArray array = JArray.Load(reader);
            foreach (var item in array)
            {
                pc.Add(item.ToObject<ChildDTO>());
            }
            return pc;
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
