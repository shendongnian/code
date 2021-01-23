        public class Channel
        {
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("sortkey")]
            public string SortKey { get; set; }
            [JsonProperty("sourceid")]
            public string SourceId { get; set; }            
        }
        public class MainItem
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("icon")]
            public string Icon { get; set; }
            [JsonProperty("channels")]
            public List<Channel> Channels { get; set; }
        }
