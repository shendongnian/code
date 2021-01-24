            public class RootObject
            {
                public Rates rates { get; set; }
                public string start_at { get; set; }
                public string @base { get; set; }
                public string end_at { get; set; }
            }
    
            public class Rates
            {
                [JsonExtensionData]
                public Dictionary<string, JToken> Fields { get; set; }
            }
    
           
