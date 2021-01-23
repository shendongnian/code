    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://graph.facebook.com/me/photos"));
    request.ContentType = "multipart/form-data";
    request.Method = "POST";
    request.BeginGetRequestStream(ar =>
    {
        using (StreamWriter writer = new StreamWriter((ar.AsyncState as HttpWebRequest).EndGetRequestStream(ar)))
        {
            writer.Write("{0}={1}&", "message", HttpUtility.UrlEncode("Test"));
            writer.Write("{0}=@{1}&", "source", HttpUtility.UrlEncode("3.png"));
            writer.Write("{0}={1}", "access_token", this.Access_Token);
        }
    }, request);
