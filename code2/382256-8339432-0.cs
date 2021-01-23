    public void YourMainFunction()
    {
        var urls = new List<string>();
        urls.Add("http://google.com");
        urls.Add("http://yahoo.com");
        foreach(var url in urls)
        {
            Task.Factory.StartNew<DownloadResult>(() => 
                 DownloadIt(url))
                 .ContinueWith(WorkDone, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
    private class DownloadResult
    {
        public string Url {get; set;}
        public string Result {get; set;}
    }
    private DownloadResult DownloadIt(string url)
    {
        var downloadResult = new DownloadResult{ Url = url };
        var client = new WebClient();
        downloadResult.Result = client.DownloadString(url);
        return downloadResult;
    }
    private void WorkDone(Task<DownloadResult> task)
    {
        if(task.IsFaulted)
        {
            //An exception was thrown 
            MessageBox.Show(task.Exception.ToString());
            return;
        }
        //Everything went well
        var downloadResult = task.Result;
        //Here you can update your UI to reflect progress.
        MessageBox.Show(downloadResult.Result);
        
    }
