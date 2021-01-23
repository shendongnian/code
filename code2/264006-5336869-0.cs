    WebClient webClient = new WebClient();
    webClient.UploadFileAsync(address, fileName);
    webClient.UploadProgressChanged += WebClientUploadProgressChanged;
    webClient.UploadFileCompleted += WebClientUploadCompleted;
    
    ...
    
    void WebClientUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
    {
         Console.WriteLine("Download {0}% complete. ", e.ProgressPercentage);
    }
    void WebClientUploadCompleted(object sender, UploadFileCompletedEventArgs e)
    {
        // The upload is finished, clean up
    }
