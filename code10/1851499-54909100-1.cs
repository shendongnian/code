    using Newtonsoft.Json;
    
    class Program
    {
        public partial class RootObject
        {
            [JsonProperty("detectedLanguage")]
            public DetectedLanguage DetectedLanguage { get; set; }
    
            [JsonProperty("translations")]
            public Translation[] Translations { get; set; }
        }
    
        public partial class DetectedLanguage
        {
            [JsonProperty("language")]
            public string Language { get; set; }
    
            [JsonProperty("score")]
            public long Score { get; set; }
        }
    
        public partial class Translation
        {
            [JsonProperty("text")]
            public string Text { get; set; }
    
            [JsonProperty("to")]
            public string To { get; set; }
        }
    
        public partial class RootObject
        {
            public static RootObject[] FromJson(string jsonresponse) => JsonConvert.DeserializeObject<RootObject[]>(jsonresponse);
        }
    
        static void Main(string[] args)
        {
            var response = client.SendAsync(request).Result;
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            var result = RootObject.FromJson(jsonResponse);
            System.Console.WriteLine(result[0].DetectedLanguage.Language); //outputs "en"
        }
    }
