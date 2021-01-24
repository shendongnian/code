    public class Config
    {
        public string MyProperty1 { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(DefaultArrayConverter))]
        public List<int> MyProperty2 { get; set; } = new List<int> { 4, 5, 6 };
    }
