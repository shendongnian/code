    string sTestes = "I like sweat peaches";
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < 5000000; i++)
        {
            for (int z = 0; z < 500; z++)
            {
                var x = string.IsNullOrEmpty(sTestes);// OR string.IsNullOrWhiteSpace
            }
        }
        stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;
        // Format and display the TimeSpan value. 
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
        Console.ReadLine();
