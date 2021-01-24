    public partial class StackOverFlow
    {
        [JsonProperty("payLoad")]
        public PayLoad PayLoad { get; set; }
    }
    public partial class PayLoad
    {
        [JsonProperty("DataSetCommonQuery")]
        public DataSetCommonQuery DataSetCommonQuery { get; set; }
    }
    public partial class DataSetCommonQuery
    {
        [JsonProperty("operator")]
        public string Operator { get; set; }
        [JsonProperty("rules")]
        public DataSetCommonQueryRule[] Rules { get; set; }
    }
    public partial class DataSetCommonQueryRule
    {
        [JsonProperty("field", NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }
        [JsonProperty("condition", NullValueHandling = NullValueHandling.Ignore)]
        public string Condition { get; set; }
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
        [JsonProperty("operator", NullValueHandling = NullValueHandling.Ignore)]
        public string Operator { get; set; }
        [JsonProperty("rules", NullValueHandling = NullValueHandling.Ignore)]
        public RuleRule[] Rules { get; set; }
    }
    public partial class RuleRule
    {
        [JsonProperty("field")]
        public string Field { get; set; }
        [JsonProperty("condition")]
        public string Condition { get; set; }
        [JsonProperty("value")]
        public Value Value { get; set; }
    }
    public partial struct Value
    {
        public long? Integer;
        public string String;
        public static implicit operator Value(long Integer) => new Value { Integer = Integer };
        public static implicit operator Value(string String) => new Value { String = String };
    }
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ValueConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    internal class ValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Value) || t == typeof(Value?);
        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new Value { Integer = integerValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Value { String = stringValue };
            }
            throw new Exception();
        }
        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Value)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception();
        }
        public static readonly ValueConverter Singleton = new ValueConverter();
    }
 
