    public string ReturnAccessToken()
    {
        HttpCookie cookie = htc.Request.Cookies[string.Format("fbsr_{0}", facebookAppID)];
        string jsoncode = System.Text.ASCIIEncoding.ASCII.GetString(FromBase64ForUrlString(cookie.Value.Split(new char[] { '.' })[1]));
    
        JsonData data = JsonMapper.ToObject(jsoncode);
    
        getAccessToken(data["code"].ToJson()
    }
    
    private string getAccessToken(string code)
    {
        //Notice the empty redirect_uri! And the replace on the code we get from the cookie.
        string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", "YOUR_APP_ID", "", "YOUR_APP_SECRET", code.Replace("\"", ""));
    
        System.Net.HttpWebRequest request = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
        System.Net.HttpWebResponse response = null;
    
        using (response = request.GetResponse() as System.Net.HttpWebResponse)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
    
            string retVal = reader.ReadToEnd();
            return retVal;
        }
    }
    
    public byte[] FromBase64ForUrlString(string base64ForUrlInput)
    {
        int padChars = (base64ForUrlInput.Length % 4) == 0 ? 0 : (4 - (base64ForUrlInput.Length % 4));
        StringBuilder result = new StringBuilder(base64ForUrlInput, base64ForUrlInput.Length + padChars);
        result.Append(String.Empty.PadRight(padChars, '='));
        result.Replace('-', '+');
        result.Replace('_', '/');
        return Convert.FromBase64String(result.ToString());
    }
