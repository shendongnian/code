    public class User
    {
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string email { get; set; }
    
        [JsonProperty("nickname", NullValueHandling = NullValueHandling.Ignore)]
        public string nickname { get; set; }
    
        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string password { get; set; }
    
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public sring image { get; set; }
    }
    public class YourUsersData
    {
      [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public List<User> Users { get; set; }
    }
