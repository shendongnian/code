    public Task<string> GetData()
    {
        TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
        NSUrl url = new NSUrl("https://reqres.in/api/users?page=2");
        NSUrlRequest request = new NSUrlRequest(url);
        NSUrlSession session = null;
        NSUrlSessionConfiguration myConfig = NSUrlSessionConfiguration.DefaultSessionConfiguration;
        myConfig.MultipathServiceType = NSUrlSessionMultipathServiceType.Handover;
        session = NSUrlSession.FromConfiguration(myConfig);
        NSUrlSessionTask task = session.CreateDataTask(request, (data, response, error) => {
            //Console.WriteLine(data);
            //tell the TaskCompletionSource that we are done here:
            tcs.TrySetResult(data); //assuming data is a string but i guess you can convert it if not
        });
        task.Resume();
        return tcs.Task;
    }
