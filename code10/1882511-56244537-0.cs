    private static void RepeatInBackgroundThread(Action action, int timeout,
        CancellationToken cancellationToken)
    {
        var timer = new System.Timers.Timer(timeout);
        timer.AutoReset = false; // to raise the Elapsed event only once
        var thread = new Thread(() =>
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested) return;
                timer.Start();
                action();
                timer.Stop();
            }
        });
        timer.Elapsed += (sender, e) =>
        {
            thread.Abort();
            thread.Join(); // Wait for the thread to die
            if (cancellationToken.IsCancellationRequested) return;
            RepeatInBackgroundThread(action, timeout, cancellationToken);
        };
        thread.IsBackground = true;
        thread.Start();
    }
