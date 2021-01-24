    public class UserAccount
    {
        // This will be serialized
        public int Id { get; set; }
        // This will not be serialized
        [JsonIgnore]
        public string Name { get; set; }
        // This will also not be serialized
        [JsonIgnore]
        public string Email { get; set; }
    }
