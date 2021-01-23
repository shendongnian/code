    public void StartPolling()
    {
        Stopwatch watch = new Stopwatch();
        while (Engine.IsRunning)
        {
            watch.Restart();
            Poll();
            watch.Stop();
            if(Frequency > watch.Elapsed) Thread.Sleep(Frequency - watch.Elapsed);
        }
    }
