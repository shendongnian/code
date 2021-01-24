    [DataContract]
    public class UserCustomType 
    {
        [JsonProperty("$type")]
        [DataMember(Name = "$type")]
        public string @Type { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
