    var htmlResultList = UriList.AsParallel()
                                .WithDegreeOfParallelism(10)
                                .AsOrdered()
                                .Select(url => { WebClient wc = new WebClient(); return wc.DownloadString(url); })
                                .ToList();
