    private string GetHeader(string method, string cKey, string cSecret, string tSecret, string tValue, string apiUrl)
    {
        Dictionary<string, string> oauthD = new Dictionary<string, string>();
        oauthD.Add("consumerKey", cKey);
        oauthD.Add("consumerSecret", cSecret);
        oauthD.Add("tokenSecret", tSecret);
        oauthD.Add("tokenValue", tValue);
        oauthD.Add("url", apiUrl);
        var timeStamp =  ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
        var nonce = Convert.ToBase64String(Encoding.UTF8.GetBytes(timeStamp));
        string[] lexOrdering = new string[6];
        lexOrdering[0] = UpperCaseUrlEncode("oauth_consumer_key=" + oauthD["consumerKey"]);
        lexOrdering[1] = UpperCaseUrlEncode("oauth_version=1.0");
        lexOrdering[2] = UpperCaseUrlEncode("oauth_timestamp=" + timeStamp);
        lexOrdering[3] = UpperCaseUrlEncode("oauth_signature_method=HMAC-SHA1");
        lexOrdering[4] = UpperCaseUrlEncode("oauth_token=" + oauthD["tokenValue"]);
        lexOrdering[5] = UpperCaseUrlEncode("oauth_nonce=" + UpperCaseUrlEncode(nonce));
        string orderedString = LexicographicalOrder(lexOrdering);
        var key1 = Encoding.Default.GetBytes(oauthD["consumerSecret"]);
        var key2 = Encoding.Default.GetBytes(oauthD["tokenSecret"]);
        var key = UpperCaseUrlEncode(Encoding.UTF8.GetString(key1)) + "&" + UpperCaseUrlEncode(Encoding.UTF8.GetString(key2));
        string signatureString = Hash(key, method.ToUpper() + "&" + UpperCaseUrlEncode(oauthD["url"]) + "&" + orderedString);
        signatureString = UpperCaseUrlEncode(signatureString);     
        string header =
            "OAuth oauth_consumer_key=\"" + oauthD["consumerKey"] + "\"," +
            "oauth_token=\"" + oauthD["tokenValue"] + "\"," +
            "oauth_signature_method=\"HMAC-SHA1\"," +
            "oauth_timestamp=\"" + timeStamp + "\"," +
            "oauth_nonce=\"" + UpperCaseUrlEncode(nonce) + "\"," +
            "oauth_version=\"1.0\"," +
            "oauth_signature=\"" + signatureString + "\"";
        return header;
    }
    private string Hash(string Key, string Data)
    {
        Byte[] secretBytes = UTF8Encoding.UTF8.GetBytes(Key);
        HMACSHA1 hmac = new HMACSHA1(secretBytes);
        Byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(Data);
        Byte[] calcHash = hmac.ComputeHash(dataBytes);
        String calcHashString = Convert.ToBase64String(calcHash);
        return calcHashString;
    }
    private string UpperCaseUrlEncode(string s)
    {
        char[] temp = HttpUtility.UrlEncode(s).ToCharArray();
        for (int i = 0; i < temp.Length - 2; i++)
        {
            if (temp[i] == '%')
            {
                temp[i + 1] = char.ToUpper(temp[i + 1]);
                temp[i + 2] = char.ToUpper(temp[i + 2]);
            }
        }
        return new string(temp).Normalize();
    }
