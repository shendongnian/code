    public class Token
    {
       public readonly string access_token;
       public readonly string token_type = Constants.TokenTypeBearer;
       public readonly int expires_in;
       public Token(string encodedJsonWebToken, int expiresInSeconds)
       {
          access_token = encodedJsonWebToken;
          expires_in = expiresInSeconds;
       }
    }
