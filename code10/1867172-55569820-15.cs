    public class MyClass
    {
        public string Qaz { get; set; }
        public string Wsx { get; set; }
    
        [JsonExtensionData]
        public Dictionary<string, JToken> child { get; set; }
    
        public MyClass()
        {
            child = new Dictionary<string, JToken>();
        }
    }
