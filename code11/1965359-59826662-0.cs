    static async Task<bool> CheckConnection(List<string> urlList)
    {
        bool succeed = true;
        using (HttpClient client = new HttpClient())
        {
            var tasks = urlList.Select(x => client.GetByteArrayAsync(x)).ToArray();
            try
            {
                await Task.WhenAll(tasks);
            }
            catch
            {
                succeed = false;
            }
        }
        return succeed;
    }
