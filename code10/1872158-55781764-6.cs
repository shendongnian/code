    public class Vehicle
    {
        [JsonProperty("owner_type")]
        public EnumOwnerType OwnerType { get; set; }
    
        [JsonProperty("owner")]
        public JObject Owner { get; set; }
    }
