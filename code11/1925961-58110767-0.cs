    {
        // Create the service using the client credentials.
        var storageService = new StorageService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "APP_NAME_HERE"
            });
        // Get the client request object for the bucket and desired object.
        var getRequest = storageService.Objects.Get("BUCKET_HERE", "OBJECT_HERE");
        using (var fileStream = new System.IO.FileStream(
            "FILE_PATH_HERE",
            System.IO.FileMode.Create,
            System.IO.FileAccess.Write))
        {
            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            getRequest.MediaDownloader.ProgressChanged += Download_ProgressChanged;
            getRequest.Download(fileStream);
        }
    }
    
    static void Download_ProgressChanged(IDownloadProgress progress)
    {
        Console.WriteLine(progress.Status + " " + progress.BytesDownloaded);
    }
