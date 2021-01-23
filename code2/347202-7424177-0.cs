    WebClient client = new WebClient();
    Uri uri = new Uri(address);
    // Specify a progress notification handler.
    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
    client.DownloadDataAsync(uri);
    static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
    {
        // Displays the operation identifier, and the transfer progress.
        Console.WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...", 
            (string)e.UserState, 
            e.BytesReceived, 
            e.TotalBytesToReceive,
            e.ProgressPercentage);
    }
