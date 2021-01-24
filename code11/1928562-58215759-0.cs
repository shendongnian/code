    
    public class ModesList
    {
        [JsonProperty("modes")]
        public List<Mode> Modes { get; set; }
    }
    public class Mode
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("shortName")]
        public string ShortName { get; set; }
        public List<string> Channels { get; set; }
    }
