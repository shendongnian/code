    public void send(string url)
    {
        WebClient c = new WebClient();
        c.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCompleted);
        c.DownloadStringAsync(new Uri(url));
    }
