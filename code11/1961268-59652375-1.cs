        //Thread-safe collection to hold results
        ConcurrentBag<string> results { get; set; } = new ConcurrentBag<string>();
        List<string> urls { get; set; } = new List<string>() { "www.google.com", "www.facebook.com", "www.yahoo.com" };
        //List to hold URL watchers
        List<UrlWatcher> watchers { get; set; } = new List<UrlWatcher>(); 
        private void StartBtn_Click(object sender, EventArgs e)
        {
            //Create a separate watcher for each URL. Subscribe to the OnDataReceived event. Start the watchers.
            foreach(var url in urls)
            {
                UrlWatcher w = new UrlWatcher(url);
                w.OnDataReceived += (o, oe) => results.Add(oe.CollectedData);
                w.Start();
                watchers.Add(w);
            }
        }
