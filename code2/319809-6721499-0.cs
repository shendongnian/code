    private void Start_Click(object sender, RoutedEventArgs e)
    {
        m_tokenSource = new CancellationTokenSource();
        var urls = …;
        Task.Factory.StartNew(() => Start(urls, m_tokenSource.Token));
    }
    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        m_tokenSource.Cancel();
    }
    void Start(IEnumerable<string> urlList, CancellationToken token)
    {
        try
        {
            Parallel.ForEach(urlList, new ParallelOptions { CancellationToken = token },
                             url => DownloadOne(url, token));
        }
        catch (OperationCanceledException)
        {}
    }
    void DownloadOne(string url, CancellationToken token)
    {
        ReportStart(url);
        try
        {
            var request = WebRequest.Create(url);
            var asyncResult = request.BeginGetResponse(null, null);
            WaitHandle.WaitAny(new[] { asyncResult.AsyncWaitHandle, token.WaitHandle });
            if (token.IsCancellationRequested)
            {
                request.Abort();
                return;
            }
            var response = request.EndGetResponse(asyncResult);
            using (var stream = response.GetResponseStream())
            {
                byte[] bytes = new byte[4096];
                while (true)
                {
                    asyncResult = stream.BeginRead(bytes, 0, bytes.Length, null, null);
                    WaitHandle.WaitAny(new[] { asyncResult.AsyncWaitHandle,
                                               token.WaitHandle });
                    if (token.IsCancellationRequested)
                        break;
                    var read = stream.EndRead(asyncResult);
                    if (read == 0)
                        break;
                    // do something with the downloaded bytes
                }
            }
            response.Close();
        }
        finally
        {
            ReportFinish(url);
        }
    }
