    public class Config {
        [JsonSerializationBatch("1")]
        public string Property1 {get; set;} = "foo";
        [JsonSerializationBatch("1")]
        public string Property2 {get; set;} = "bar";
        [JsonSerializationBatch("2")]
        public string Property3 {get; set;} = "baz";
        [JsonSerializationBatch("2")]
        public string Property4 {get; set;} = "baz1";
    }
3. Then implement conditional serialization as described here:
https://www.newtonsoft.com/json/help/html/ConditionalProperties.htm
in the serialization function check if a property has `JsonSerializationBatch` attribute with proper string and ignore all properties that do not.
I would do this complex thing only if I would have many objects that need this type of serialization. If only one object requires such serialization then I would lean towards splitting class into more than one or using anonymous objects for serialization.
