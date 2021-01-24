    private async void TestWebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
    {
        if (args.Uri != null && args.Uri.OriginalString.ToLower().Contains(".exe"))
        {
            try
            {
    
                StorageFile destinationFile = await KnownFolders.PicturesLibrary.CreateFileAsync(
                    "test.exe", CreationCollisionOption.GenerateUniqueName);
    
                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(args.Uri, destinationFile);
                await download.StartAsync();
            }
            catch (Exception ex)
            {
    
            }
        }
    }
