    using Newtonsoft.Json;
    
    namespace Models.Salesforce
    {
        public class SalesforceLoginResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }
    }
