[JsonProperty("JsonPropertyName")]
     public partial class Root
        {
            [JsonProperty("_id")]
            public string Id { get; set; }
    
            [JsonProperty("taskInstance")]
            public TaskInstance[] TaskInstances { get; set; }
    
            [JsonProperty("isRunning")]
            public bool IsRunning { get; set; }
        }
    
        public partial class TaskInstance
        {
            [JsonProperty("_id")]
            public string Id { get; set; }
        }
