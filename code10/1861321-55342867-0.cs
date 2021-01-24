    private void DownloadFiles(string[] targets)
    {
        var tasks = new List<Task>();
        using (var wc = new WebClient())
        {
            foreach (var target in targets)
            {
                var task = DownloadFile(wc, target);
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
        
    private Task DownloadFile(WebClient wc, string target)
    {            
        wc.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
        {
             Console.WriteLine(e.ProgressPercentage + "% downloaded.");
        };
        wc.DownloadFileCompleted += (object sender, AsyncCompletedEventArgs e) =>
        {
             Console.WriteLine(target + " was downloaded.");
             // TODO: Signal this "Task" is done
        };
    
        return wc.DownloadFileTaskAsync(target, localPath);
     }
