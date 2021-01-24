    var thread = new Thread(() =>
    {
        try
        {
        }
        catch (ThreadAbortException)
        {
            Console.WriteLine("ThreadAbortException");
            throw;
        }
        finally
        {
            Console.WriteLine("Thread Finally Started");
            Thread.Sleep(200);
            Console.WriteLine("Thread Finally Finished");
        }
    })
    { IsBackground = true };
    thread.Start();
    Thread.Sleep(100);
    Console.WriteLine("Aborting...");
    thread.Abort();
    thread.Join();
