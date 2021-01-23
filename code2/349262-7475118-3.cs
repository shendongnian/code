    static IEnumerable<string> GetSources(List<string> pages)
    {
        var sources = new BlockingCollection<string>();
        var latch = new CountdownEvent(pages.Count);
    
        foreach (var p in pages)
        {
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                using (var wc = new WebClient())
                {
                    wc.DownloadStringCompleted += (x, e) =>
                    {
                        sources.Add(e.Result);
                        latch.Signal();
                    };
    
                    wc.DownloadStringAsync(new Uri(p));
                }
            });
        }
    
        latch.Wait();
    
        return sources;
    }
