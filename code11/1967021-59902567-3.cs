    public partial class AdditionalAttribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public Value Value { get; set; }
    }
    public partial struct Value
    {
        public string _value;
        public List<string> _valueArray;
    
        public static implicit operator Value(string value) => new Value { _value = value};
        public static implicit operator Value(List<string> valueArray) => new Value { _valueArray= valueArray};
    }
