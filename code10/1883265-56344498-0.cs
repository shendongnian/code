    if (strUrl.StartsWith("HTTPS", StringComparison.OrdinalIgnoreCase)) ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
    WebRequest webRequest = WebRequest.Create(strUrl);
    webRequest.ContentType = "application/x-www-form-urlencoded";
    webRequest.Method = "Get";
    using (WebResponse webResponse = webRequest.GetResponse())
    {
        if (webResponse == null) return blnResult;
        using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
        {
           strSuccess = sr.ReadToEnd().Trim();
           blnResult = true;
        }
    }
