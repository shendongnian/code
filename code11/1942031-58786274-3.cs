    using System.Management;  // Need assembly reference added to project
    Console.Write("Console resolution in char:");
    Console.Write(Console.WindowWidth + "x" + Console.WindowHeight);
    var scope = new ManagementScope();
    scope.Connect();
    var query = new ObjectQuery("SELECT * FROM Win32_VideoController");
    using ( var searcher = new ManagementObjectSearcher(scope, query) )
      foreach ( var result in searcher.Get() )
        Console.WriteLine("Screen resolution in pixels: {0}x{1}",
                          result.GetPropertyValue("CurrentHorizontalResolution"),
                          result.GetPropertyValue("CurrentVerticalResolution"));
