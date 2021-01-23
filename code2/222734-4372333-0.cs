    static void Run(string file)
    {
        using (Process p = new Process()) {
            p.StartInfo.FileName = @"binary.exe";
            p.StartInfo.Arguments = file;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
        }
    }
    
    static WaitHandle RunAsync(string file)
    {
        Action<string> result = new Action<string>(Run).BeginInvoke(file, null, null);
        return result.AsyncWaitHandle;
    }
    
    static void Main()
    {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("1.mp3");
        queue.Enqueue("2.mp3");
        queue.Enqueue("3.mp3");
        queue.Enqueue("4.mp3");
        queue.Enqueue("5.mp3");
        queue.Enqueue("6.mp3");
        // ...
        queue.Enqueue("10000.mp3");
    
    
        const int MaxRunningProcesses = 5;
    
        List<WaitHandle> runningProcesses = new List<WaitHandle>(MaxRunningProcesses);
        
        while (queue.Count > 0 && runningProcesses.Count < MaxRunningProcesses) {
            runningProcesses.Add(RunAsync(queue.Dequeue()));
        }
    
        while (runningProcesses.Count > 0) {
            int j = WaitHandle.WaitAny(runningProcesses.ToArray());
            runningProcesses[j].Close();
            runningProcesses.RemoveAt(j);
            if (queue.Count > 0) {
                runningProcesses.Add(RunAsync(queue.Dequeue()));
            }
        }
    }
