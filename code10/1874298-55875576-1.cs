    using (_webClient = new WebClient())
    {
        try
        {
            await _webClient.DownloadFileTaskAsync("https://speed.hetzner.de/100MB.bin", @"D:\100MB.bin");
        }
        catch (WebException ex) when (ex.Status == WebExceptionStatus.RequestCanceled)
        {
            Console.WriteLine("Cancelled");
        }
    }
