    private static void HandleElapsed(object sender, ElapsedEventArgs e)
    {
        numEvents += 1;
    
        // This example assumes that overlapping events can be
        // discarded. That is, if an Elapsed event is raised before 
        // the previous event is finished processing, the second
        // event is ignored. 
        //
        // CompareExchange is used to take control of syncPoint, 
        // and to determine whether the attempt was successful. 
        // CompareExchange attempts to put 1 into syncPoint, but
        // only if the current value of syncPoint is zero 
        // (specified by the third parameter). If another thread
        // has set syncPoint to 1, or if the control thread has
        // set syncPoint to -1, the current event is skipped. 
        // (Normally it would not be necessary to use a local 
        // variable for the return value. A local variable is 
        // used here to determine the reason the event was 
        // skipped.)
        //
        int sync = Interlocked.CompareExchange(ref syncPoint, 1, 0);
        if (sync == 0)
        {
            // No other event was executing.
            // The event handler simulates an amount of work
            // lasting between 50 and 200 milliseconds, so that
            // some events will overlap.
            int delay = timerIntervalBase 
                - timerIntervalDelta / 2 + rand.Next(timerIntervalDelta);
            Thread.Sleep(delay);
            numExecuted += 1;
    
            // Release control of syncPoint.
            syncPoint = 0;
        }
        else
        {
            if (sync == 1) { numSkipped += 1; } else { numLate += 1; }
        }
    }
