    WebClient webClient = new WebClient();
    webClient.DownloadProgressChanged += (s, e) =>
    {
        progressBar.Value = e.ProgressPercentage;
    };
    webClient.DownloadFileCompleted += (s, e) =>
    {
        progressBar.Visible = false;
        // any other code to process the file
    };
    webClient.DownloadFileAsync(new Uri("http://example.com/largefile.dat"),
        @"C:\Path\To\Output.dat");
