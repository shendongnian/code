    List<FileDownloader> filewonloadersList = new ListFileDownloader>();
    System.Net.WebRequest req = System.Net.HttpWebRequest.Create("http://stackoverflow.com/robots.txt");
    req.Method = "HEAD";
    System.Net.WebResponse resp = req.GetResponse();
    int responseLength = int.Parse(resp.Headers.Get("Content-Length"));
    for(int i = 0;i<response.Length;i = i + 1024){
    filewonloadersList.Add(new FileDownloader("http://stackoverflow.com/robots.txt",i,1024));
    }
