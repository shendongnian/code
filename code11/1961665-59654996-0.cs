    public class Level2 { public string MyKey { get; set; } }
    public class Level1
    {
        [JsonProperty("top.level")]
        public Level2 TopLevel { get; set; }
    }
