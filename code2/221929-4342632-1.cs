    static volatile bool processing = true;
    static void Stop()
    {
        processing = false;
        //wait until the 'worker' completes processing the current item.
        worker.Join();
        Console.WriteLine("{0} Items Processed", itemsProcessed);
    }
    static void Run(object state)
    {
        while (proccessing)
        {
            ALongRunningTask();
            itemsProcessed++;
        }
    }
