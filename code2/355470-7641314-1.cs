    var tasks = Enumerable.Range(0, 10)
        .Select(i => DownloadAndEnqueue(i))
        .ToArray();
    await Task.WhenAll(tasks);
    m_queue.FinishAdding();
    …
    static async Task DownloadAndEnqueue(string url)
    {
        m_queue.Enqueue(await DownloadFile(url));
    }
