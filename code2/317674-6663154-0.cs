    public static void RequestAsync(Uri url, Action<string, Exception> callback)
    {
        if (callback == null)
        {
            throw new ArgumentNullException("callback");
        }
        try
        {
            var req = WebRequest.CreateHttp(url);
            AsyncCallback getTheResponse = ar =>
            {
                try
                {
                    string responseString;
                    var request = (HttpWebRequest)ar.AsyncState;
                    using (var resp = (HttpWebResponse)request.EndGetResponse(ar))
                    {
                        using (var streamResponse = resp.GetResponseStream())
                        {
                            using (var streamRead = new StreamReader(streamResponse))
                            {
                                responseString = streamRead.ReadToEnd();
                            }
                        }
                    }
                    callback(responseString, null);
                }
                catch (Exception ex)
                {
                    callback(null, ex);
                }
            };
            req.BeginGetResponse(getTheResponse, req);
        }
        catch (Exception ex)
        {
            callback(null, ex);
        }
    }
