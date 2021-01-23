    System.Runtime.MemoryFailPoint memFailPoint = null;
    int memUsageInMB = 100;
    bool isEnoughMemory = false;
    
    try
    {
    	// Check for available memory.
    	memFailPoint = new MemoryFailPoint(memUsageInMB);
    	isEnoughMemory = true;
    }
    catch (InsufficientMemoryException e)
    {
    	// MemoryFailPoint threw an exception.
    	Console.WriteLine("Expected InsufficientMemoryException thrown.  Message: " + e.Message);
    }
    
    if (isEnoughMemory)
    {
    	// Perform the operation.
    }
    else
    {
    	// Show error message.
    }
