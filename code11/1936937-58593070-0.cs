    foreach (var file in driveFiles) {
    		var fileId = file.Id;
    		var request = driveService.Files.Get(fileId);
    		var stream = new System.IO.MemoryStream();
    
    		// Add a handler which will be notified on progress changes.
    		// It will notify on each chunk download and when the
    		// download is completed or failed.
    		request.MediaDownloader.ProgressChanged +=
    				(IDownloadProgress progress) =>
    		{
    				switch (progress.Status)
    				{
    						case DownloadStatus.Downloading:
    								{
    										Console.WriteLine(progress.BytesDownloaded);
    										break;
    								}
    						case DownloadStatus.Completed:
    								{
    										Console.WriteLine("Download complete.");
    										break;
    								}
    						case DownloadStatus.Failed:
    								{
    										Console.WriteLine("Download failed.");
    										break;
    								}
    				}
    		};
    		
    		IDownloadProgress result = await request.DownloadAsync(stream);    
    }
