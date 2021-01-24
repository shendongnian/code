    AppDomain workerAppDomain = AppDomain.CreateDomain("WorkerAppDomain");
    workerAppDomain.SetData("URL", "https://stackoverflow.com");
    workerAppDomain.DoCallBack(() =>
    {
        var url = (string)AppDomain.CurrentDomain.GetData("URL");
        Console.WriteLine($"Scraping {url}");
        var webClient = new WebClient();
        var content = webClient.DownloadString(url);
        AppDomain.CurrentDomain.SetData("OUTPUT", content.Length);
    });
    int contentLength = (int)workerAppDomain.GetData("OUTPUT");
    AppDomain.Unload(workerAppDomain);
    Console.WriteLine($"ContentLength: {contentLength:#,0}");
