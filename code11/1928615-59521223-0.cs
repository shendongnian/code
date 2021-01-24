    /* ----- In the Main Thread ----- */
    Thread t = new Thread(() => waitForProcessClose(newProcess));
    t.Start();
    while (t.IsAlive)
    {
    	Thread.Sleep(500);                         
    }
    /* ----- In the Main Thread ----- */
    
    
    public static bool waitForProcessClose(Process handleToProcess)
    {
    	handleToProcess.WaitForExit();
    
    	return true;
    }
