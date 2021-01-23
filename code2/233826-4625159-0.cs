    using System.Diagnostics;
   
    protected PerformanceCounter ramCounter;
    ramCounter = new PerformanceCounter("Memory", "Available MBytes");
    /*
    Call this method every time you need to get
    the amount of the available RAM in Mb
    */
    public string getAvailableRAM()
    {
         ramCounter.NextValue()+"Mb";
    } 
