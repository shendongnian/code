    var tasks = photos.Select(  p => Task.Factory.StartNew(() =>
            {
                using(WebClient webClient = new WebClient())
                webClient.DownloadFile(p.src_big, string.Format(@"C:\pic{0}.jpg",p.ID));
            })).ToArray();
    Task.WaitAll(tasks);
