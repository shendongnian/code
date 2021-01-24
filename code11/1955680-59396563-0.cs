      public partial class Question
        {
            [JsonProperty("Active")]
            public bool Active { get; set; }
    
            [JsonProperty("CompletedMessage")]
            public string CompletedMessage { get; set; }
    
            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }
    
            [JsonProperty("Description")]
            public string Description { get; set; }
    
            [JsonProperty("DisplayName")]
            public string DisplayName { get; set; }
    
            [JsonProperty("ID")]
            public Guid Id { get; set; }
    
            [JsonProperty("QuestionsIDs")]
            public Guid[] QuestionsIDs { get; set; }
    
            [JsonProperty("WelcomeMessage")]
            public string WelcomeMessage { get; set; }
        }
