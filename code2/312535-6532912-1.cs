    /// <summary>
    /// Append a url parameter to a string builder, url-encodes the value
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    protected void AppendParameter(StringBuilder sb, string name, string value)
    {
        string encodedValue = HttpUtility.UrlEncode(value);
        sb.AppendFormat("{0}={1}&", name, encodedValue);
    }
    private void SendDataToService()
    {
        StringBuilder sb = new StringBuilder();
        AppendParameter(sb, "email", "hello@example.com");
        byte[] byteArray = Encoding.UTF8.GetBytes(sb.ToString());
        string url = "http://example.com/"; //or: check where the form goes
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        //request.Credentials = CredentialCache.DefaultNetworkCredentials; // ??
        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(byteArray, 0, byteArray.Length);
        }
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        // do something with response
    }
