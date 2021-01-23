    IEnumerable<Task<string>> DownloadAllUrl(string[] urls)
    {
        foreach(var url in urls)
        {
            yield return DownloadHtmlAsync(url);
        }
    }
    async Task<string> DownloadHtmlAsync(url)
    {
        // Do your downloading here...
    }
