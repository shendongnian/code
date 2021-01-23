    [JsonConverter(typeof(JsonKnownTypeConverter<BaseClass>))]
    [JsonKnownType(typeof(Base), "base")]
    [JsonKnownType(typeof(Derived), "derived")]
    public class Base
    {
        public string Name;
    }
    public class Derived : Base
    {
        public string Something;
    }
    
