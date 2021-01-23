    try
    {
        request = yahoo.PrepareAuthorizedRequest(YahooContactsAPIEndpoint, TokenManager.currentToken.Token, extraData);
        response = yahoo.Channel.WebRequestHandler.GetResponse(request);
        body = response.GetResponseReader().ReadToEnd();
    }
    catch (DotNetOpenAuth.Messaging.ProtocolException ex)
    {
        //is token expired?
        if (ex.InnerException is WebException
            && ((WebException)ex.InnerException).Response is HttpWebResponse
            && ((HttpWebResponse)((WebException)ex.InnerException).Response).StatusCode == HttpStatusCode.Unauthorized)
        {
            RefreshYahooAccessToken();
            request = yahoo.PrepareAuthorizedRequest(YahooContactsAPIEndpoint, TokenManager.currentToken.Token, extraData);
            response = yahoo.Channel.WebRequestHandler.GetResponse(request);
            body = response.GetResponseReader().ReadToEnd();
        }
    }
    
    
    private static void RefreshYahooAccessToken()
    {
        var request = (HttpWebRequest)WebRequest
            .Create("https://api.login.yahoo.com/oauth/v2/get_token"
                + "?oauth_consumer_key=" + TokenManager.ConsumerKey
                + "&oauth_nonce=" + (new Random()).Next(123400, 9999999).ToString()
                + "&oauth_session_handle=" + TokenManager.GetExtraData("oauth_session_handle") //this value is given to you in the get_token Response Parameters
                + "&oauth_signature=" + TokenManager.ConsumerSecret + "%26" + TokenManager.currentToken.Secret
                + "&oauth_signature_method=PLAINTEXT"
                + "&oauth_timestamp=" + (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds.ToString().Split(new char[] { '.' })[0]
                + "&oauth_token=" + TokenManager.currentToken.Token
                + "&oauth_version=1.0");
        try
        {
            var response = (HttpWebResponse)request.GetResponse();
            var returnStr = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            var returnData = System.Web.HttpUtility.ParseQueryString(returnStr ?? string.Empty);
            TokenManager.ExpireRequestTokenAndStoreNewAccessToken(null, null, returnData["oauth_token"], returnData["oauth_token_secret"]);
        }
        catch (Exception)
        {
            //User probably revoked token.  Clear the current token, and request authorization again
        }
    }
