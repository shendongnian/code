    public class Rootobject
    {
        public Response Response { get; set; }
    }
    
    public class Response
    {
        public Outcome Outcome { get; set; }
    }
    
    public class Outcome
    {
        public Keyvalueofstringoutcomepqnxskqu[] KeyValueOfstringOutcomepQnxSKQu { get; set; }
    }
    
    public class Keyvalueofstringoutcomepqnxskqu
    {
        public string Key { get; set; }
        public Value Value { get; set; }
    }
    
    public class Value
    {
        public string DataType { get; set; }
        public string Field { get; set; }
        [JsonProperty("Value")]
        public string Value1 { get; set; }
    }
 
