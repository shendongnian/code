    public class Schema
    {
        [JsonProperty("Property")]
        public List<Property> Properties { get; set; }
    }
    public abstract class Property
    {
        public string Type { get; set; }
    }
    public class NotSumProperty : Property
    {
        public string Rule { get; set; }
    }
    public class SumProperty : Property
    {
        public Config Config { get; set; }
    }
    public class Config
    {
        [JsonProperty("Rule")]
        public List<Rule> Rules { get; set; }
    }
    public class Rule
    {
        public string Type { get; set; }
        public int Value { get; set; }
    }
