    private static void Main()
    {
        var sleepTime = TimeSpan.FromSeconds(5);
        var sleepyTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("I'm going to sleep");
            // Before sleeping, launch a countdown timer
            Task.Factory.StartNew(() =>
            {
                Countdown(sleepTime);
            });
            // Now go to sleep
            Thread.Sleep(sleepTime);
            Console.WriteLine("I'm back!");
        });
        sleepyTask.Wait();
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
    private static void Countdown(TimeSpan time)
    {
        var seconds = time.TotalSeconds;
        // Write something once per second for 'seconds' seconds
        while (seconds > 0)
        {
            Console.WriteLine(seconds--);
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
