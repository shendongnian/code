    Timer wakeSleepingIdsTimer = new Timer(
       _ =>
       {
           DateTime utcNow = DateTime.UtcNow;
           // Pull all items from the sleeping queue that have been there for at least 2 seconds
           foreach(string id in sleepingIds.TakeWhile(entry => (utcNow - entry.Item2).TotalSeconds >= 2))
           {
               // Add this id back to the processing queue
               idsToProcess.Enqueue(id);
           }
       },
       null, // no state
       Timeout.Infinite, // no due time
       100 // wake up every 100ms, probably should read this from config
     );
