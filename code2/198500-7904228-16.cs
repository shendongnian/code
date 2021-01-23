    public class ETradeTokenManager : IConsumerTokenManager 
    {
        private Dictionary<string, string> tokensAndSecrets = new Dictionary<string, string>();
	public string ConsumerKey { get { return "YourConsumerKey"; } }
	public string ConsumerSecret { get { return "YourConsumerSecret";  } }
		
	public string GetTokenSecret(string token)
	{
	    return tokensAndSecrets[token];
	}
	public void StoreNewRequestToken(UnauthorizedTokenRequest request, ITokenSecretContainingMessage response)
	{
	    tokensAndSecrets[response.Token] = response.TokenSecret;
	}
	public void ExpireRequestTokenAndStoreNewAccessToken(string consumerKey, string requestToken, string accessToken, string accessTokenSecret)
	{
	    tokensAndSecrets.Remove(requestToken);
	    tokensAndSecrets[accessToken] = accessTokenSecret;
	}
	public TokenType GetTokenType(string token)
	{
	    throw new NotImplementedException();
	}
    }
