    var tasks = photos.Select(  p => Task.Factory.StartNew(() =>
            {
                using(WebClient webClient = new WebClient())
                webClient.DownloadFile(p.src_big, "D:\\samples\\" + p.ID + ".jpg");
            })).ToArray();
    Task.WaitAll(tasks);
