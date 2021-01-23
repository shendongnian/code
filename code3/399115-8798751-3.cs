    PageWatcher watcher = new PageWatcher(index, url, name, timer);
    watcher.ConnectionAttempt += HandleConnectionAttempt;
    thSystem[index] = new Thread(new ThreadStart(watcher.StartProcess));
    thSystem[index].Start();
    ...
    void HandleConnectionAttempt(object sender, ConnectionAttemptEventArgs e)
    {
         Console.WriteLine("Connection attempt watcher {0}, result {1}", e.Index, e.Result);
    }
