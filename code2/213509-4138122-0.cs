    private void DownloadString(string address)
    {
        WebClient client = new WebClient();
        Uri uri = new Uri(address);
        
        client.DownloadStringCompleted += DownloadStringCallback;
        client.DownloadStringAsync(uri);
        StartWaitAnimation();
    }
    private void DownloadStringCallback(object sender, DownloadStringCompletedEventArgs e)
    {
        // Do something with e.Result (which is the returned string)
     
        StopWaitAnimation();
    }
