    void WalkDirectoryTree(System.IO.DirectoryInfo root)
    {
        System.IO.FileInfo[] files = null;
        System.IO.DirectoryInfo[] subDirs = null;
    
    
        // First, process all the files directly under this folder
        try
        {
    	    files = root.GetFiles("*.*");
        }
        // This is thrown if even one of the files requires permissions greater
        // than the application provides.
        catch (UnauthorizedAccessException e)
        {
        }
        catch (System.IO.DirectoryNotFoundException e)
        {
        }
    
        if (files != null)
        {
    	  foreach (System.IO.FileInfo fi in files)
    	  {
    
    	  }
    
    	  // Now find all the subdirectories under this directory.
    	  subDirs = root.GetDirectories();
    
    
    	  foreach (System.IO.DirectoryInfo dirInfo in subDirs)
    	  {
    	    // Resursive call for each subdirectory.
    	    WalkDirectoryTree(dirInfo);
    	  }
        }
    }
