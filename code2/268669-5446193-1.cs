    public string Download()
    {
        var manualEvent = new ManualResetEvent(false);
        WebClient client = new WebClient();
        var result = string.Empty;
        client.DownloadStringCompleted += (sender, e) =>
        {
            if (e.Error != null)
            {
                result = e.Result;
            }
            manualEvent.Set();
        };
        client.DownloadStringAsync(new Uri(Application.Current.Host.Source.AbsoluteUri + "\\PHP\\GetAdmins.php"));
        // block while the download is completed and the event is signaled or
        // timeout after 30 seconds
        if (!manualEvent.WaitOne(TimeSpan.FromSeconds(30)))
        {
            // timeout
        }
        return result;
    }
