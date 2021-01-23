    public static void MakeRequest(Uri uri, Action<Stream> responseCallback)
    {
        WebRequest request = WebRequest.Create(uri);
        request.Proxy = null;
        const int TimeoutPeriod = 1000;
        Task<WebResponse> t = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
        ThreadPool.RegisterWaitForSingleObject((t as IAsyncResult).AsyncWaitHandle, TimeoutCallback, request, TimeoutPeriod, true);
        t.ContinueWith(task =>
        {
            WebResponse response = task.Result;
            Stream responseStream = response.GetResponseStream();
            responseCallback(response.GetResponseStream());
            responseStream.Close();
            response.Close();
        });
    }
