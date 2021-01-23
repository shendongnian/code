    Queue<string> queue = new Queue<string>();
    queue.Enqueue("1.mp3");
    queue.Enqueue("2.mp3");
    queue.Enqueue("3.mp3");
    ...
    queue.Enqueue("10000.mp3");
    int runningProcesses = 0;
    const int MaxRunningProcesses = 5;
    object syncLock = new object();
        
    Action<string> run = new Action<string>(delegate(string file) {
        using (Process p = new Process()) {
            p.StartInfo.FileName = @"binary.exe";
            p.StartInfo.Arguments = file;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.WaitForExit();
        }
    });
    
    Action runNext = null;
    runNext = delegate() {
        lock (syncLock) {
            if (queue.Count > 0) {
                run.BeginInvoke(queue.Dequeue(), new AsyncCallback(delegate {
                    runNext();
                }), null);
            }
        }
    };
    
    while (runningProcesses++ < MaxRunningProcesses) {
        runNext();
    }
