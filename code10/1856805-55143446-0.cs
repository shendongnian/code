    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Test()
        {
            var json1 = "{\"field1\":\"value1\",\"field2\":false}";
            var deserializedWithBool = JsonConvert.DeserializeObject<ObjectJson>(json1);
            var json2 = "{\"field1\":\"value1\",\"field2\": { \"field21\" : \"value21\", \"field22\" : \"value22\"}}";
            var deserializedWithObject = JsonConvert.DeserializeObject<ObjectJson>(json2);
            Assert.AreEqual("value21", deserializedWithObject.field2.field21);
        }
    }
    public class ObjectJson
    {
        public string field1 { get; set; }
        [JsonConverter(typeof(FieldJsonConverter))]
        public Field field2 { get; set; }
    }
    public class Field
    {
        public string field21 { get; set; }
        public string field22 { get; set; }
    }
    public class FieldJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Field));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                return token.ToObject<Field>();
            }
            return null;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
