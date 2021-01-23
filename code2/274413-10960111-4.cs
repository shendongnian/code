    [JsonObject]
    public class FacebookSession
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
    
    var facebokSession = JsonConvert.DeserializeObject<FacebookSession>(facebookSessionJsonString);
