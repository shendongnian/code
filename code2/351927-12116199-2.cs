    // Create a stack of the directories to be processed.
    Stack<DirectoryInfo> dirstack = new Stack<DirectoryInfo>();
    // Add your initial directory to the stack.
    dirstack.Push(new DirectoryInfo(@"D:\");
    
    // While there are directories on the stack to be processed...
    while (dirstack.Count > 0)
    {
    	// Set the current directory and remove it from the stack.
    	DirectoryInfo current = dirstack.Pop();
    
    	// Get all the directories in the current directory.
    	foreach (DirectoryInfo d in current.GetDirectories())
    	{
    		// Only add a directory to the stack if it is not a system directory.
    		if ((d.Attributes & FileAttributes.System) != FileAttributes.System)
    		{
    			dirstack.Push(d);
    		}
    	}
    	
    	// Get all the files in the current directory.
    	foreach (FileInfo f in current.GetFiles())
    	{
    		// Do whatever you want with the files here.
    	}
    }
