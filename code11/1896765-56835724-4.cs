    IEnumerable<string[]> toParse = myData
        .Select((v, i) => new { v.code, group = i / 20 })
        .GroupBy(x => x.group)
        .Select(g => g.Select(x => x.code).ToArray());
    using (HttpClient client = new HttpClient()) {
        foreach (string[] _group in toParse) {
            string[] _pages = null;
            IEnumerable<Task<string>> _downloads = _group
                .Select(job => {
                    return client.GetStringAsync(<url with job>);
                });
            Task<string>[] _downloadTasks = _downloads.ToArray();
            _pages = await Task.WhenAll(_downloadTasks);
            await Task.Delay(5000);
        }
    }
