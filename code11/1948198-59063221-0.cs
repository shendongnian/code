    public class FlatternKeysConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
    		Module o = (Module)value;
    		JObject newObject = new JObject(new JProperty(o.Name, o.Permission));
    		newObject.WriteTo(writer);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }
    
        public override bool CanRead
        {
            get { return false; }
        }
    
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
