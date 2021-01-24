    public class Application
    {
        [JsonProperty("roles")]
        public IEnumerable<string> Roles { get; set; }
    }
    public class User
    {
        [JsonProperty("user_info")]
        public IDictionary<string, Application> UserInfo { get; set; }
    }
