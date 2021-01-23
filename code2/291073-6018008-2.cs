    // we need to keep a list of synchronization events
    var finishEvents = new List<EventWaitHandle>();
    for (int i = 0; i < records.Count; i++ )
    {
        // for each job, create an event and add it to the list
        var signal = new EventWaitHandle(false, EventResetMode.ManualReset);
        finishEvents.Add(signal);
        // we need to catch the id in a separate variable
        // for the closure to work as expected
        var id = records[i];
        var thread = new Thread(() =>
            {
                // do the job
                ThreadJob(id);
                // signal the main thread
                signal.Set();
            });
    }
    WaitHandle.WaitAll(finishEvents.ToArray());
