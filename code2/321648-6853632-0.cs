    // Create the new progress object
    BatchProgress bs = new BatchProgress(0);
    if(Application["BatchProgress"] != null)
    {
        // Should never happen
        Application["BatchProgress"] = bs;
    }
    else
    {
        Application.Add("BatchProgress","bs");
    }
    
    //Set up new thread, run batch is the method that does all the processing.
    ThreadStart ts = new ThreadStart(RunBatch);
    Thread t = new Thread(ts);
    t.Start();
