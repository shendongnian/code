    void BatchProcess()
    {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("1.mp3");
        queue.Enqueue("2.mp3");
        queue.Enqueue("3.mp3");
        ...
        queue.Enqueue("10000.mp3");
    
        WaitHandle[] subprocesses = new WaitHandle[Math.Min(queue.Count, 5)];
        for( int i = 0; i < subprocesses.Length; i++ ) {
            subprocesses[i] = Spawn(queue.Dequeue());
        }
        while (queue.Count > 0) {
            int j = WaitHandle.WaitAny(subprocesses);
            subprocesses[j].Dispose();
            subprocesses[j] = Spawn(queue.Dequeue());
        }
    
        WaitHandle.WaitAll(subprocesses);
        foreach (var wh in subprocesses) {
            wh.Dispose();
        }
    }
    ProcessWaitHandle Spawn(string args)
    {
        using (Process p = new Process()) {
            p.StartInfo.FileName = @"binary.exe";
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            return p.WaitHandle;
        }
    }
