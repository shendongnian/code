     string Link = args.Uri.Segments.Last();
     try
     {
         var messagedialog = new MessageDialog("Saving File " + Link + " to your Download folder.");
         await messagedialog.ShowAsync();
         StorageFile destinationFile = await DownloadsFolder.CreateFileAsync(Link, CreationCollisionOption.GenerateUniqueName);
         BackgroundDownloader downloader = new BackgroundDownloader();
         DownloadOperation download = downloader.CreateDownload(args.Uri, destinationFile);
         await download.StartAsync();
     }
     catch (Exception e)
     {
    
    
     }
