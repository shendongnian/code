    public static void UpdateDatabase(object con) 
    { 
        if (Monitor.TryEnter(myLock)) 
        {
           System.Diagnostics.Debug.WriteLine("Doing the work");
            Thread.Sleep(5000); 
            Monitor.Exit(myLock);
            System.Diagnostics.Debug.WriteLine("Done doing the work");
        } 
        else 
        {
            System.Diagnostics.Debug.WriteLine("Entrance was blocked");
        } 
    } 
