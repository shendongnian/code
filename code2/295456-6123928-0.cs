    private static object processLock = new object();  // probably static
    
    public void Method4()
    {
       lock(processLock)
       {
           process1.Start(); 
       }
    }
