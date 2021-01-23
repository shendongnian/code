        TaskCompletionSource<int> tcs1 = new TaskCompletionSource<int>();
        Task<int> t1 = tcs1.Task;
        // Start a background task that will complete tcs1.Task
        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000);
            tcs1.SetResult(15);
        });
        // The attempt to get the result of t1 blocks the current thread until the completion source gets signaled.
        // It should be a wait of ~1000 ms.
        Stopwatch sw = Stopwatch.StartNew();
        int result = t1.Result;
        sw.Stop();
        Console.WriteLine("(ElapsedTime={0}): t1.Result={1} (expected 15) ", sw.ElapsedMilliseconds, result);
