c#
        class IgnoreNullList : DefaultContractResolver
        {
            protected override JsonContract CreateContract(Type objectType)
            {
                JsonContract contract = base.CreateContract(objectType);
                if (objectType == typeof(List<string>))
                {
                    contract.Converter = new MyNullIgnorer();
                }
                return contract;
            }
        }
    internal class MyNullIgnorer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                JToken token = JToken.Load(reader);
                List<string> items = token.ToObject<List<string>>();
                return items;
            }
            return null;
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
And in your code convert your object with custom converter.
c#
....
            var setting = new JsonSerializerSettings()
            {
                ContractResolver = new IgnoreNullList()
            };
var test = JsonConvert.DeserializeObject<Family>(yourJsonString, setting);
