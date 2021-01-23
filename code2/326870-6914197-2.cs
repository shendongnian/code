    // Information used in callbacks.
    class DownloadArgs
    {
        public readonly string Url;
        public readonly string Filename;
        public readonly WebClient Client;
        public DownloadArgs(string u, string f, WebClient c)
        {
            Url = u;
            Filename = f;
            Client = c;
        }
    }
    const int MaxClients = 4;
    // create a queue that allows the max items
    BlockingCollection<WebClient> ClientQueue = new BlockingCollection<WebClient>(MaxClients);
    // queue of urls to be downloaded (unbounded)
    Queue<string> UrlQueue = new Queue<string>();
    // create four WebClient instances and put them into the queue
    for (int i = 0; i < MaxClients; ++i)
    {
        var cli = new WebClient();
        cli.DownloadProgressChanged += DownloadProgressChanged;
        cli.DownloadFileCompleted += DownloadFileCompleted;
        ClientQueue.Add(cli);
    }
    // Fill the UrlQueue here
    // Now go until the UrlQueue is empty
    while (UrlQueue.Count > 0)
    {
        WebClient cli = ClientQueue.Take(); // blocks if there is no client available
        string url = UrlQueue.Dequeue();
        string fname = CreateOutputFilename(url);  // or however you get the output file name
        cli.DownloadFileAsync(new Uri(url), fname, 
            new DownloadArgs(url, fname, cli));
    }
    void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        DownloadArgs args = (DownloadArgs)e.UserState;
        // Do status updates for this download
    }
    void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        DownloadArgs args = (DownloadArgs)e.UserState;
        // do whatever UI updates
        // now put this client back into the queue
        ClientQueue.Add(args.Client);
    }
