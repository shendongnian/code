    public void OnGetBuffer(IAsyncResult asr)
    {
        HttpWebResponse webResp;
        try
        {
            webResp = (HttpWebResponse)webReq.EndGetResponse(asr);
        }
        Catch (WebException ex)
        {
            // Do something to decide whether to retry, then retry or else
            throw; // Re-throw if you're not going to handle the exception
        }
        
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            using (Stream streamResult = webResp.GetResponseStream())
            {
                // Do something with the stream
            }
        });
    }
