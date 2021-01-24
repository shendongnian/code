    public class TokenResponse
    {
        [Newtonsoft.Json.JsonPropertyAttribute("access_token")]
        public string AccessToken { get; set; }
        
        [Newtonsoft.Json.JsonPropertyAttribute("token_type")]
        public string TokenType { get; set; }
        
        [Newtonsoft.Json.JsonPropertyAttribute("expires_in")]
        public Nullable<long> ExpiresInSeconds { get; set; }
        
        [Newtonsoft.Json.JsonPropertyAttribute("refresh_token")]
        public string RefreshToken { get; set; }
        
        [Newtonsoft.Json.JsonPropertyAttribute("scope")]
        public string Scope { get; set; }
        
        [Newtonsoft.Json.JsonPropertyAttribute("id_token")]
        public string IdToken { get; set; }
        
        [Obsolete("Use IssuedUtc instead")]
        [Newtonsoft.Json.JsonPropertyAttribute(Order = 1)] 
        public DateTime Issued
        {
            get { return IssuedUtc.ToLocalTime(); }
            set { IssuedUtc = value.ToUniversalTime(); }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute(Order = 2)]
        public DateTime IssuedUtc { get; set; }
        ...
    }
