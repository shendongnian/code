    // Assume the nums.length == tokens.length
    int[] nums = Enumerable.Range(0, 10000000).ToArray();
    CancellationToken[] tokens = ...
    try
    {
        Parallel.ForEach(nums, (num) =>
        {
            tokens[num].ThrowIfCancellationRequested();
            double d = Math.Sqrt(num);
            Console.WriteLine("{0} on {1}", d, Thread.CurrentThread.ManagedThreadId);        
        });
    }
    catch (AggregateException e)
    {
        // One or more tasks was canceled or threw an exception.
        // e.InnerExceptions contains the individual OperationCanceledException
        // or other exceptions that were thrown.
    }
