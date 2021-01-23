        var watch = Stopwatch.StartNew();
        for (int i = 0; i < 100000; i++) 
        {
            action(); //Equals and GetHashCode called here to test for performance.
        }
        watch.Stop();
        Console.WriteLine(watch.Elapsed.TotalMilliseconds);
