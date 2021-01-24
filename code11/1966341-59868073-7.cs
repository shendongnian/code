    public class NestedPropertyConverter : JsonConverter
    {
        private string[] _properties;
        public NestedPropertyConverter(string propertyChain)
        {
            //todo: check if property chain has valid structure
            _properties = propertyChain.Split('.');
        }
        public override bool CanWrite => false;
        public override bool CanConvert(Type objectType) => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = (JToken)serializer.Deserialize(reader);
            foreach (string property in _properties)
            {
                token = token[property];
                if (token == null) //if property doesn't exist
                    return existingValue; //or throw exception
            }
            return token.ToObject(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
