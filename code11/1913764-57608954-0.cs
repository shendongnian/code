    private async void StartDownloadAsync(object sender, RoutedEventArgs e)
    {
      ...
    
      var fileId = "1QETWTnkIp9q6O35Rm99qC6LsJ4Gdg3I5";
    
      progressBar.Minimum = 0;
      progressBar.Maximum = 100;
      progressBar.Value = 50;
    
      // Creating an instance of Progress<T> captures the current 
      // SynchronizationContext (UI context) to prevent cross threading when updating the ProgressBar
      IProgress<double> progressReporter = new Progress<double>(value => progressBar.Value = value);
      await DownloadAsync(progressReporter, fileId);
    }
    
    
    private async Task DownloadAsync(progressReporter, string fileId)
    {
      var streamDownload = new MemoryStream();
    
      var request = driveService.Files.Get(fileId);
      var file = request.Execute();
      long? fileSize = file.Size;
      // Report progress to UI via the captured UI's SynchronizationContext
      request.MediaDownloader.ProgressChanged += (progress) => 
        ReportProgress(progress, progressReporter, fileSize);
    
      // Execute download asynchronous
      await Task.Run(() => request.Download(streamDownload));
    }
    
    
    private void ReportProgress(IDownloadProgress progress, IProgress<double> progressReporter, long? fileSize)
    {
      switch (progress.Status)
      {
        case DownloadStatus.Downloading:
        {
          double progressValue = Convert.ToDouble(progress.BytesDownloaded * 100 / fileSize);
          progressReporter.Report(progressValue);
          break;
        }
        case DownloadStatus.Completed:
        {
          Console.WriteLine("Download complete.");
          using (FileStream fs = new FileStream("downloaded.zip", FileMode.OpenOrCreate))
          {
            streamDownload.WriteTo(fs);
            fs.Flush();
          }
          break;
        }
        case DownloadStatus.Failed:
        {
          break;
        }
      }
    }
