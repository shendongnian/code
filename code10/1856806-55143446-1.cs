    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Test()
        {
            var json1 = "{\"field1\":\"value1\",\"field2\":true}";
            var deserializedWithBool = JsonConvert.DeserializeObject<ObjectJson>(json1);
            var json2 = "{\"field1\":\"value1\",\"field2\": { \"field21\" : \"value21\", \"field22\" : \"value22\"}}";
            var deserializedWithObject = JsonConvert.DeserializeObject<ObjectJson>(json2);
            Assert.AreEqual(true, deserializedWithBool.field2.field2BoolResult);
            Assert.AreEqual("value21", deserializedWithObject.field2.field21);
        }
    }
    public class ObjectJson
    {
        public string field1 { get; set; }
        [JsonConverter(typeof(FieldJsonConverter))]
        public FieldResult field2 { get; set; }
    }
    public class FieldResult
    {
        public bool? field2BoolResult { get; set; }
        public string field21 { get; set; }
        public string field22 { get; set; }
    }
    public class FieldJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(FieldResult));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Boolean)
            {
                return new FieldResult() { field2BoolResult  = (bool)(JValue)token };
            }
            else if (token.Type == JTokenType.Object)
            {
                return token.ToObject<FieldResult>();
            }
            throw new InvalidOperationException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
