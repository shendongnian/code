    [JsonConverter(typeof(JsonSubtypes), "valueType")]
    [JsonSubtypes.KnownSubType(typeof(IntItem), "int")]
    [JsonSubtypes.KnownSubType(typeof(StringItem), "string")]
    public abstract class Item
    {
        public string ValueType { get; set; }
        [JsonProperty("valueTypeId")]
        public int ValueTypeId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public override string ToString()
        {
            return "Base object, we dont' want base created ValueType=" + this.ValueType + "; " + "name: " + Name;
        }
    }
    public class StringItem : Item
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("numberChars")]
        public int NumberCharacters { get; set; }
        public override string ToString()
        {
            return "StringItem object ValueType=" + this.ValueType + ", Value=" + this.Value + "; " +
                   "Num Chars= " + NumberCharacters;
        }
    }
    public class IntItem : Item
    {
        [JsonProperty("value")]
        public int Value { get; set; }
        public override string ToString()
        {
            return "IntItem object ValueType=" + this.ValueType + ", Value=" + this.Value;
        }
    }
    [TestMethod]
    public void Demo()
    {
        // json string
        var json =
            "[{\"value\":5,\"valueType\":\"int\",\"valueTypeId\":1,\"name\":\"numberOfDups\"}," +
            "{\"value\":\"some thing\",\"valueType\":\"string\",\"valueTypeId\":1,\"name\":\"a\",\"numberChars\":11}," +
            "{\"value\":2,\"valueType\":\"int\",\"valueTypeId\":2,\"name\":\"b\"}]";
        var result = JsonConvert.DeserializeObject<List<Item>>(json);
        Assert.AreEqual("IntItem object ValueType=int, Value=5", result[0].ToString());
        Assert.AreEqual("StringItem object ValueType=string, Value=some thing; Num Chars= 11", result[1].ToString());
        Assert.AreEqual("IntItem object ValueType=int, Value=2", result[2].ToString());
    }
