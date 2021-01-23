    protected override void OnInvoke(ScheduledTask task)
    {
        var fetchTask = FetchData(TimeSpan.FromSeconds(10));
        fetchTask.ContinueWith(x =>
        {
            Deployment.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                string strResult = x.Result; // mind you, x.Result will be "null" when a timeout occours.
            
                ...
                NotifyComplete();
            }));
        });
    }
    private Task<string> FetchData(TimeSpan timeout)
    { 
        var tcs = new TaskCompletionSource<string>();
        var request = (HttpWebRequest)WebRequest.Create(new Uri("site.com"));
        Timer timer = null;
        timer = new Timer(sender =>
        {
            tcs.TrySetResult(null);
            timer.Dispose();
        }, null, (int)timeout.TotalMilliseconds, Timeout.Infinite);
        request.BeginGetResponse(r =>
        {
            var httpRequest = (HttpWebRequest)r.AsyncState;
            var httpResponse = (HttpWebResponse)httpRequest.EndGetResponse(r);
            using (var reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var response = reader.ReadToEnd();
                tcs.TrySetResult(response);
            }
        });
        return tcs.Task;
    }
