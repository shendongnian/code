    private void StartDownload()
    {
        WebClient client = new WebClient();
        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler((object sender, DownloadStringCompletedEventArgs e) =>
        {
            if (e.Error == null) // <== because of this
            {
                data = e.Result;
            }
            closed = true;
            sendAndComplete();
        });    
        client.DownloadStringAsync(new Uri(url));
    }
