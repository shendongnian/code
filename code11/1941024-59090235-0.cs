    [JsonConverter(typeof(DerivedTypeConverter))]
    public abstract class Base
    { 
        [JsonProperty("$type")]
        public abstract string Type { get; }
    }
    public class Child : Base
    {
        public override string Type => nameof(Child);
    }
    public class Child2 : Base
    {
        public override string Type => nameof(Child2);
    }
