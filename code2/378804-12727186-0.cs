    public class JsonItemConverter :  Newtonsoft.Json.Converters.CustomCreationConverter<Item>
    {
        public override Item Create(Type objectType)
        {
            throw new NotImplementedException();
        }
        
        public Item Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("valueType");
            switch (type)
            {
                case "int":
                    return new IntItem();
                case "string":
                    return new StringItem();
            }
            throw new ApplicationException(String.Format("The given vehicle type {0} is not supported!", type));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
            // Create target object based on JObject
            var target = Create(objectType, jObject);
            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
    }
    public abstract class Item
    {
        public string ValueType { get; set; }
        [JsonProperty("valueTypeId")]
        public int ValueTypeId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public new virtual string ToString() { return "Base object, we dont' want base created ValueType=" + this.ValueType + "; " + "name: " + Name; }
    }
    public class StringItem : Item
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("numberChars")]
        public int NumberCharacters { get; set; }
        public override string ToString() { return "StringItem object ValueType=" + this.ValueType + ", Value=" + this.Value + "; " + "Num Chars= " + NumberCharacters; }
    }
    public class IntItem : Item
    {
        [JsonProperty("value")]
        public int Value { get; set; }
        public override string ToString() { return "IntItem object ValueType=" + this.ValueType + ", Value=" + this.Value; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // json string
            var json = "[{\"value\":5,\"valueType\":\"int\",\"valueTypeId\":1,\"name\":\"numberOfDups\"},{\"value\":\"some thing\",\"valueType\":\"string\",\"valueTypeId\":1,\"name\":\"a\",\"numberChars\":11},{\"value\":2,\"valueType\":\"int\",\"valueTypeId\":2,\"name\":\"b\"}]";
   
            // The above is deserialized into a list of Items, instead of a hetrogenous list of
            // IntItem and StringItem
            var result = JsonConvert.DeserializeObject<List<Item>>(json, new JsonItemConverter());
 
            foreach (var r in result)
            {
                // r is an instance of Item not StringItem or IntItem
                Console.WriteLine("got " + r.ToString());
            }
        }
    }
