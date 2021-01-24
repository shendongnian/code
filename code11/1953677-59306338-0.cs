    public class Person
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PhysicalPerson PhysicalPerson { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public OtherPerson OtherPerson { get; set; }
    }
    
