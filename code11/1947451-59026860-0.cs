    public class Host
    {
        [JsonProperty(PropertyName = "hostname")]
        public string Hostname { get; set; }
    	[JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }
    	[JsonProperty(PropertyName = "mac")]
        public string Mac { get; set; }
    	[JsonProperty(PropertyName = "timeStamp")]
        public DateTime? TimeStamp { get; set; }
    	[JsonProperty(PropertyName = "updates")]
        public List<Updates> Updates { get; set; }
    }
    
    public class Updates
    {
        [JsonProperty(PropertyName = "updateID")]
        public string UpdateId { get; set; }
    	[JsonProperty(PropertyName = "updateDetails")]
        public List<UpdateDetails> UpdateDetails { get; set; }
    }
    
    public class UpdateDetails
    {
        [JsonProperty(PropertyName = "patchDescription")]
        public string PatchDescription { get; set; }
    	[JsonProperty(PropertyName = "patchCategory")]
        public string PatchCategory { get; set; }
    	[JsonProperty(PropertyName = "patchType")]
        public string PatchType { get; set; }
    	[JsonProperty(PropertyName = "patchName")]
        public string PatchName { get; set; }
    }
