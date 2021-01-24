    public class BankJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                JProperty transactionProperty = o.Properties().FirstOrDefault(p => p.Name == "Transaction");
                o.Remove("Transaction");
                JToken token = transactionProperty;
                foreach (JToken ct in token.Children())
                {
                    foreach (var prop in JProperty.FromObject(ct))
                    {
                        o.Add(prop);
                    }
                }
                serializer.Serialize(writer, o);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }
        public override bool CanRead => false;
        public override bool CanConvert(Type objectType)
        {
             return objectType.GetInterfaces().Contains(typeof(IBankData));
        }
    } 
