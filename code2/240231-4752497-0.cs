    private System.Diagnostics.PerformanceCounter ramCounter; 
    ramCounter = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes"); 
     
    public string getAvailableRAM()
    {
          return ramCounter.NextValue() + "Mb";
    }
