    public delegate void IntDelegate(int Int);
    public static event IntDelegate FileCopyProgress;
    public static void CopyFileWithProgress(string source, string destination)
    {
        var webClient = new WebClient();
        webClient.DownloadProgressChanged += DownloadProgress;
        webClient.DownloadFileAsync(new Uri(source), destination);
    }
    private static void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
    {
        if(FileCopyProgress != null)
            FileCopyProgress(e.ProgressPercentage);
    }
