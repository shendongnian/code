    private async static Task DownloadAsync(string url, string filePath)
    {
        using (var webClient = new WebClient())
        {
            IWebProxy webProxy = WebRequest.DefaultWebProxy;
            webProxy.Credentials = CredentialCache.DefaultCredentials;
            webClient.Proxy = webProxy;
            webClient.DownloadProgressChanged += (s, e) => Console.Write($"{e.ProgressPercentage}%");
            webClient.DownloadFileCompleted += (s, e) => Console.WriteLine();
            await webClient.DownloadFileTaskAsync(new Uri(url), filePath).ConfigureAwait(false);
        }
    }
