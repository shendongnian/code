        public class UserInfo
        {
            [JsonProperty("user_info")]
            public Dictionary<string, Account> Users { get; set; }
        }
        public class Account
        {
            [JsonProperty("roles")]
            public List<string> Roles { get; set; }
        }
