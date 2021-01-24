    public class RootObject
    {
        [JsonProperty("User_")]
        public User User { get; set; }
    }
    
    public class User
    {
        [JsonProperty("Email_")]
        public string Email { get; set; }
    
        [JsonProperty("Password_")]
        public string Password { get; set; }
    }
