    Parallel.ForEach(
        idsToProcess.GetConsumingEnumerable(),
        new ParallelOptions 
        { 
            MaxDegreeOfParallelism = 4 // read this from config
        },
        (id) =>
        {
           // ... execute sproc ...
           // Need to declare/assign this before the delegate so that we can dispose of it inside 
           Timer timer = null;
           timer = new Timer(
               _ =>
               {
                   // Add the id back to the collection so it will be processed again
                   idsToProcess.Add(id);
                   // Cleanup the timer
                   timer.Dispose();
               },
               null, // no state, id wee need is "captured" in the anonymous delegate
               2000, // probably should read this from config
               Timeout.Infinite);
        }
