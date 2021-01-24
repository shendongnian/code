    public class VehicleRecord {
        [JsonProperty(Name="clFirstName")]
        public string firstName { get; set; }
        [JsonProperty(Name="clLastName")]
        public string lastName { get; set; }
        [JsonProperty(Name="clGender")]
        public string gender { get; set; }
        //...etc
    }
