    public static void TaskCallBack(object state)
    {
        var data = (ThreadData)state;
        try
        {
            // Do work here.
            Console.WriteLine($"Thread {data.Index} is starting.");
            Thread.Sleep(_rng.Next(2000, 10000));
            Console.WriteLine($"Thread {data.Index} has finished.");
        }
        finally
        {
            data.Countdown.Signal();
        }
    }
