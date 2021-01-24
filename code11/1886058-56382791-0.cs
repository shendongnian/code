     public static void Main()
        {
    	// Create string for a directory. This value should be an existing directory
    	// or the sample will throw a DirectoryNotFoundException.
          string dir = @"C:\test";		
    	  try
    	  {
    		  //Set the current directory.
    		  Directory.SetCurrentDirectory(dir);
    	  }
    	  catch (DirectoryNotFoundException e)
    	  {
    		  Console.WriteLine("The specified directory does not exist. {0}", e);
    	  }
    	// Print to console the results.
    	  Console.WriteLine("Root directory: {0}", Directory.GetDirectoryRoot(dir));
    	  Console.WriteLine("Current directory: {0}", Directory.GetCurrentDirectory());
    }
