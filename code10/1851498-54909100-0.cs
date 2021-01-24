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
            public int Score { get; set; }
        }
    
        public partial class Translation
        {
            [JsonProperty("text")]
            public string Text { get; set; }
    
            [JsonProperty("to")]
            public string To { get; set; }
        }
