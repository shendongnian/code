        public class MyJson
        {
            [JsonProperty("pageLen")]
            public int PageLen { get; set; }
            [JsonProperty("values")]
            public Values Values { get; set; }
        }
        public class Values
        {
            [JsonProperty("rendered")]
            public Rendered Rendered { get; set; }
            [JsonProperty("hash")]
            public string Hash { get; set; }
        }
        public class Rendered
        {
        }
        
