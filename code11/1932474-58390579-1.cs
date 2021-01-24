    public class PropertyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => typeof(Property).IsAssignableFrom(objectType);
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Property p;
            switch ((string)obj["type"])
            {
                case "SumProperty":
                    p = new SumProperty();
                    break;
                default:
                    p = new NotSumProperty();
                    break;
            }
            serializer.Populate(obj.CreateReader(), p);
            return p;
        }
    }
