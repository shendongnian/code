    public void PostDataToWebService(string url, string data, Action<string, Exception> callback)
    {
        if (callback == null)
        {
            throw new Exception("callback may not be null");
        }
        try
        {
            var uri = new Uri(url, UriKind.Absolute);
            var req = HttpWebRequest.CreateHttp(uri);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            AsyncCallback GetTheResponse = ar =>
                {
                    try
                    {
                        var result = ar.GetResponseAsString();
                        callback(result, null);
                    }
                    catch (Exception ex)
                    {
                        callback(null, ex);
                    }
                };
            AsyncCallback SetTheBodyOfTheRequest = ar =>
                {
                    var request = ar.SetRequestBody(data);
                    request.BeginGetResponse(GetTheResponse, request);
                };
            req.BeginGetRequestStream(SetTheBodyOfTheRequest, req);
        }
        catch (Exception ex)
        {
            callback(null, ex);
        }
    }
    
