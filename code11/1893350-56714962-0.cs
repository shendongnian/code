 C#
[JsonConverter(typeof(HistoryDeserializer))]
    public class AccountHistory
    {
        public long Integer { get; set; }
        public Transaction transaction { get; set; }
    }
Custom JsonConverter
C#
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<Transaction>(reader);
                    return new AccountHistory { transaction = objectValue };
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new AccountHistory { Integer = integerValue };
            }
            return null;
        }
