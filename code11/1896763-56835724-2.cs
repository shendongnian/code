    using (HttpClient client = new HttpClient()) {
        IEnumerable<Task<string>> _downloads = _group
            .Select(job => {
                await Task.Delay(300);
                return client.GetStringAsync(<url with variable job>);
            });
        Task<string>[] _downloadTasks = _downloads.ToArray();
        _pages = await Task.WhenAll(_downloadTasks);
    }
