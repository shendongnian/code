    public partial class RootObject
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public partial class Data
    {
        [JsonProperty("first_name")]
        public string[] FirstName { get; set; }
        [JsonProperty("last_name")]
        public string[] LastName { get; set; }
        [JsonProperty("email")]
        public string[] Email { get; set; }
        [JsonProperty("password")]
        public string[] Password { get; set; }
    }
