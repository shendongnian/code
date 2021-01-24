    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    
    namespace JsonParse
    {
        public partial class Welcome
        {
            [JsonProperty("id")]
            public string Id { get; set; }
    
            [JsonProperty("name")]
            public string Name { get; set; }
    
            [JsonProperty("status")]
            public string Status { get; set; }
        }
    
        public partial class Welcome
        {
            public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }
    
        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
        
        class Program
        {
            static void Main(string[] args)
            {
    
                var jsonPayload = "{\"id\":\"YWauEwCUIe\",\"name\":\"User 1\",\"status\":\"DONE\"}";
                var jsonAsObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Welcome>(jsonPayload);
                Console.WriteLine($"{jsonAsObject.Id} {jsonAsObject.Name} {jsonAsObject.Status}");
                Console.ReadKey();
            }
        }
    }
