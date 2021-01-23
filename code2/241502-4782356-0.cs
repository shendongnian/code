    public Class()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
             // Do your stuff here...
    
            stopWatch.Stop();
       
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime, "RunTime");
        }
