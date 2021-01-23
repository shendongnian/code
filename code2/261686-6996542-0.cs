    [DllImport("kernel32.dll")]
    private static extern IntPtr LoadLibrary(string dllToLoad);
    [DllImport("kernel32.dll")]
    private static extern bool FreeLibrary(IntPtr hModule);    
    
    public bool IsDriverInstalled()
    {
      //trying to load library
      IntPtr handler = LoadLibrary(@"FTD2XX.DLL");
      
      if (handler == IntPtr.Zero)
          return false;
      else
          return true; // Driver is installed
    
      //Don't forget to free .dll
      FreeLibrary(handler);
    }
    
