    public static void SendMessage(string message)
    {
        try
        {
            tokens = new OAuthTokens();
            tokens.AccessToken = "Some Token";
            tokens.AccessTokenSecret = "Some Secret";
            tokens.ConsumerKey = "Some Key";
            tokens.ConsumerSecret = "Some CSecret";    
            WebProxy p = new WebProxy("10.0.0.21", 3128);
            p.Credentials = new NetworkCredential("UserName", "Password");
            StatusUpdateOptions options = new StatusUpdateOptions();
            options.Proxy = p;
           TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, message, options);
        }
    }
