    Task<IEnumerable<string>> DownLoadAllUrls(string[] urls)
    {
        // Note that Task.WhenAll is TaskEx.WhenAll in the CTP.
        return Task.WhenAll(from url in urls select DownloadHtmlAsync(url));
    }
