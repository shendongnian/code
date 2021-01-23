    private static object syncRoot = new Object();
    private static bool shouldRun = true;
    //Thread 1
    bool bContinue;
    lock(syncRoot)
        bContinue = shouldRun;
    while(bContinue) 
    {
        // Do some work ....
        lock(syncRoot)
            bContinue = shouldRun;
    }
    //Thread 2
    lock(syncRoot)
        shouldRun = false;
    
