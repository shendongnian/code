    var pipeline = new ReplaySubject<byte[]>();
    var files = pipeline.ToEnumerable();
    var client = new WebClient();
    TaskEx.WhenAll(urls
            .Select(download => client.DownloadDataTaskAsync((string) download)
                .ContinueWith(t => pipeline.OnNext(t.Result))
            )
        ).ContinueWith(task => pipeline.OnCompleted(task));
    foreach(var file in files) {
        ProcessFile(file);
    }
