    public class MyClass
    {
        public string JsonArrayString => "[{\"Value\": \"1\", \"Name\": \"One\"}, {\"Value\": \"2\", \"Name\": \"Two\"}]";
        public List<MyJsonObject> JsonArray => JsonConvert.DeserializeObject<List<MyJsonObject>>(JsonArrayString);
    }
    public class MyJsonObject
    {
        [JsonProperty("Value")]
        string Value { get; set; }
        [JsonProperty("Name")]
        string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
        }
    }
