    class ApiResult
    {
        [JsonProperty(propertyName: "option1")]
        public string Option1 { get; set; }
        [JsonProperty(propertyName: "option2")]
        public string Option2 { get; set; }
        [JsonProperty(propertyName: "id")]
        public string[] Id { get; set; }
        [JsonProperty(propertyName: "filterd")]
        public string Filter { get; set; }
        [JsonProperty(propertyName: "actualValues")]
        public ICollection<ActualValue> ActualValues { get; set; }
    }
    
    class ActualValue
    {
        [JsonProperty(propertyName: "id")]
        public int Id { get; set; }
        [JsonProperty(propertyName: "otherId")]
        public int OtherId { get; set; }
        [JsonProperty(propertyName: "valuetoExtract")]
        public string ValueToExtract { get; set; }
    }
