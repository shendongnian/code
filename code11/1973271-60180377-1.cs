    public class TokenRequest
    {
    	[JsonProperty("token_type")]
    	public string TokenType { get; set; }
    
    	[JsonProperty("access_token")]
    	public string AccessToken { get; set; }
    }
