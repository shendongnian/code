    public class ValueConverter : JsonConverter
    {
        static readonly JsonSerializerSettings SpecifiedSubclassConversion  = new JsonSerializerSettings() { ContractResolver = new CustomResolver() };
        public override bool CanConvert(Type objectType) => objectType == typeof(Value);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            return (obj["conditionType"].Value<string>()) switch
            {
                "Text" => JsonConvert.DeserializeObject<StringValue>(obj.ToString(), SpecifiedSubclassConversion),
                "DateTime" => JsonConvert.DeserializeObject<DateTimeValue>(obj.ToString(), SpecifiedSubclassConversion),
                "Boolean" => JsonConvert.DeserializeObject<BooleanValue>(obj.ToString(), SpecifiedSubclassConversion),
                "Number" => JsonConvert.DeserializeObject<IntegerValue>(obj.ToString(), SpecifiedSubclassConversion),
                "List" => JsonConvert.DeserializeObject<ListValue>(obj.ToString(), SpecifiedSubclassConversion),
                _ => throw new Exception("Unknown conditionType"),
            };
            throw new NotImplementedException();
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
    public class CustomResolver: DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(Value).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null;
            return base.ResolveContractConverter(objectType);
        }
    }
