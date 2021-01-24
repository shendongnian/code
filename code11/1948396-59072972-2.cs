    [JsonConverter(typeof(ValueConverter))]
    public abstract class Value
    {
        public string Alias { get; set; }
        public string ProviderKey { get; set; }
        public bool HasValue { get; set; }
        public string ConditionType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class BooleanValue : Value { public bool? Values { get; set; } }
    public class ListValue : Value { public List<string> Values { get; set; } }
    public class StringValue : Value { public string Values { get; set; } }
    public class DateTimeValue : Value { public DateTime? Values { get; set; } }
    public class IntegerValue : Value { public int? Values { get; set; } }
