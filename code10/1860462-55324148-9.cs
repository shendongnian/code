    class Downloader
    {
      public DownloadItem CurrentDownloadItem { get; set; }
      public WebClient webClient = new WebClient();
      public Stopwatch stopWatch = new Stopwatch();
      public event Action<long> FileSizeChanged;
      public event Action<long, TimeSpan> DownloadBytesChanged;
      public event Action<double> ProgressPercentageChanged;
      public event Action DownloadComplete;
    
    
      public void DownloadFile(DownloadItem gameToDownload)
      {
        this.CurrentDownloadItem = gameToDownload;
        if (webClient.IsBusy)
          throw new Exception("The client is busy");
    
        var startDownloading = DateTime.UtcNow;
        webClient.Proxy = null;
        if (!SelectFolder(
          Path.GetFileName(this.CurrentDownloadItem.Url) + Path.GetExtension(this.CurrentDownloadItem.Url),
          out var filePath))
        {
          DownloadingError();
          return;
        }
    
        webClient.DownloadProgressChanged += (o, args) =>
        {
          UpdateProgressPercentage(args.ProgressPercentage);
          UpdateFileSize(args.TotalBytesToReceive);
          UpdateProgressBytesRead(args.BytesReceived, DateTime.UtcNow - startDownloading);
          if (args.ProgressPercentage >= 100 && this.CurrentDownloadItem.IsOpenAfterDownloadEnabled)
            Process.Start(filePath);
        };
        webClient.DownloadFileCompleted += OnDownloadCompleted;
        stopWatch.Start();
        webClient.DownloadFileAsync(new Uri(this.CurrentDownloadItem.Url), filePath);
      }
    
      public void CancelDownloading()
      {
        webClient.CancelAsync();
        webClient.Dispose();
        DownloadComplete?.Invoke();
      }
    
      private string PrettyBytes(double bytes)
      {
        if (bytes < 1024)
          return bytes + "Bytes";
        if (bytes < Math.Pow(1024, 2))
          return (bytes / 1024).ToString("F" + 2) + "Kilobytes";
        if (bytes < Math.Pow(1024, 3))
          return (bytes / Math.Pow(1024, 2)).ToString("F" + 2) + "Megabytes";
        if (bytes < Math.Pow(1024, 4))
          return (bytes / Math.Pow(1024, 5)).ToString("F" + 2) + "Gygabytes";
        return (bytes / Math.Pow(1024, 4)).ToString("F" + 2) + "terabytes";
      }
    
      private string DownloadingSpeed(long received, TimeSpan time)
      {
        return ((double) received / 1024 / 1024 / time.TotalSeconds).ToString("F" + 2) + " megabytes/sec";
      }
    
      private string DownloadingTime(long received, long total, TimeSpan time)
      {
        var receivedD = (double) received;
        var totalD = (double) total;
        return ((totalD / (receivedD / time.TotalSeconds)) - time.TotalSeconds).ToString("F" + 1) + "sec";
      }
    
      private void OnDownloadCompleted(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
      {
      }
    
      private void UpdateProgressPercentage(double percentage)
      {
        this.CurrentDownloadItem.Progress = percentage;
      }
    
      private void UpdateProgressBytesRead(long bytes, TimeSpan time)
      {
        this.CurrentDownloadItem.ProgressBytesRead = PrettyBytes(bytes);
        this.CurrentDownloadItem.DownloadSpeed = DownloadingSpeed(bytes, time);
        this.CurrentDownloadItem.TimeElapsed = DownloadingTime(bytes, this.CurrentDownloadItem.BytesTotal, time);
      }
    
      protected virtual void UpdateFileSize(long bytes)
      {
        this.CurrentDownloadItem.DisplayBytesTotal = PrettyBytes(bytes);
      }
    
      private void DownloadingError()
        => this.CurrentDownloadItem.ErrorMessage = "Downloading Error";
    
      private static bool SelectFolder(string fileName, out string filePath)
      {
        var saveFileDialog = new SaveFileDialog
        {
          InitialDirectory = @"C:\Users\MusicMonkey\Downloads",
          FileName = fileName,
          Filter = "All files (*.*)|*.*",
        };
        filePath = "";
        if (saveFileDialog.ShowDialog() != true)
          return false;
        filePath = saveFileDialog.FileName;
        return true;
      }
    }
