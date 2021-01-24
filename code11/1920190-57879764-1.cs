     public class Token // use this for Deserialization
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }
            [JsonProperty("token_type")]
            public string TokenType { get; set; }
        }
        public class TokenDto // use this for Serialization
        {
            [JsonProperty("accessToken")]
            public string AccessToken { get; set; }
            [JsonProperty("expiresIn")]
            public int ExpiresIn { get; set; }
            [JsonProperty("tokenType")]
            public string TokenType { get; set; }
        }
    // Note that it is highly recommended 
    // to respect the C# programming convention 
    // in classes and properties naming that follow the pascalCase format
