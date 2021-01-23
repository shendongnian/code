    public static string SendRequest(string uri, string method, string contentType, string body)
    {
        string responseBody = String.Empty;
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(uri));
        req.Method = method;
        if (!String.IsNullOrEmpty(contentType))
        {
            req.ContentType = contentType;
        }
        if (!String.IsNullOrEmpty(body))
        {
            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
            req.GetRequestStream().Write(bodyBytes, 0, bodyBytes.Length);
            req.GetRequestStream().Close();
        }
        HttpWebResponse resp;
        try
        {
            resp = (HttpWebResponse)req.GetResponse();
        }
        catch (WebException e)
        {
            resp = (HttpWebResponse)e.Response;
        }
        Stream respStream = resp.GetResponseStream();
        if (respStream != null)
        {
            responseBody = new StreamReader(respStream).ReadToEnd();
        }
        return responseBody;
    }
