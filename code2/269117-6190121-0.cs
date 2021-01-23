            var client = new WebClient();
            var syncLock = new object();
            TaskEx.WhenAll(urls.Select(url => {
                client.DownloadDataTaskAsync(url).ContinueWith((t) => {
                    lock(syncLock) {
                        ProcessFile(t.Result);
                    }
                });
            }));
