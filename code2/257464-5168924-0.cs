    public static void DownloadHTML(
         string address, 
         DownloadStringCompletedEventHandler callWhenCompleted)
    {
        WebClient client = new WebClient();
    
        client.DownloadStringCompleted += 
            new DownloadStringCompletedEventHandler(callWhenCompleted);
    
        client.DownloadStringAsync(new Uri(address));
    }
    
    private void DownloadCompletedCallback(
        Object sender, DownloadStringCompletedEventArgs e)
    {
        if (!e.Cancelled && e.Error == null)
        {
            lblDebug.Content = (string)e.Result;
        }
    }
