    public class FacebookOAuth
    {
        public static IEnumerable<ExchangeSessionResult> ExchangeSessions(string appId, string appSecret, params string[] sessionKeys)
        {
            WebClient client = new WebClient();
            var dict = new Dictionary<string, object>();
            dict.Add("client_id", appId);
            dict.Add("client_secret", appSecret);
            dict.Add("sessions", String.Join(",", sessionKeys));
            string data = dict.ToJsonQueryString();
            string result = client.UploadString("https://graph.facebook.com/oauth/exchange_sessions", data);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ExchangeSessionResult[]>(result);
        }
    }
    public class ExchangeSessionResult
    {
        [Newtonsoft.Json.JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [Newtonsoft.Json.JsonProperty("expires")]
        public string Expires { get; set; }
    }
