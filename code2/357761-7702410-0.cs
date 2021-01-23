    static async Task<int> GetTotalSizeAsync(params string[] urls)
    {
        if (urls == null)
            return 0;
        var tasks = urls.Select(GetSizeAsync);
        var sizes = await TaskEx.WhenAll(tasks);
        return sizes.Sum();
    }
    static async Task<int> GetSizeAsync(string url)
    {
        try
        {
            var str = await new WebClient().DownloadStringTaskAsync(url);
            return str.Length;
        }
        catch (WebException)
        {
            return 0;
        }
    }
