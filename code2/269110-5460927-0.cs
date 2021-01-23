    var q = new Queue<MyFile>();
    var ev = new ManualResetEvent(false);
    
    new System.Threading.Thread(() =>
    {
        while ( true )
        {
            ev.WaitOne();
            MyFile item;
            lock (q)
            {
                item = q.Dequeue();
                if ( q.Count == 0 )
                    ev.Reset();
            }
            if ( item == null )
                break;
            ProcessFile(item);
        }
    }).Start();
    foreach(string url in urls)
    {
        var file = FetchFile(url);
        lock (q)
        {
            q.Enqueue(file);
            ev.Set();
        }
    }
    lock (q)
    {
        q.Enqueue(null);
        ev.Set();
    }
