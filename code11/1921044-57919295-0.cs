    private static void DownloadFile(Google.Apis.Drive.v3.DriveService service, Google.Apis.Drive.v3.Data.File file, string saveTo)
            {
    
                var request = service.Files.Get(file.Id);
                var stream = new System.IO.MemoryStream();
    
                // Add a handler which will be notified on progress changes.
                // It will notify on each chunk download and when the
                // download is completed or failed.
                request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
                   {
                       switch (progress.Status)
                       {
                           case Google.Apis.Download.DownloadStatus.Downloading:
                               {
                                   Console.WriteLine(progress.BytesDownloaded);
                                   break;
                               }
                           case Google.Apis.Download.DownloadStatus.Completed:
                               {
                                   Console.WriteLine("Download complete.");
                                   SaveStream(stream, saveTo);
                                   break;
                               }
                           case Google.Apis.Download.DownloadStatus.Failed:
                               {
                                   Console.WriteLine("Download failed.");
                                   break;
                               }
                       }
                   };
                request.Download(stream);
    
            }
    private static void SaveStream(System.IO.MemoryStream stream, string saveTo)
    {
         using (System.IO.FileStream file = new System.IO.FileStream(saveTo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
             stream.WriteTo(file);
             }
    }
