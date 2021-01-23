    try
    {
    	// Some code that can cause an exception.
    
    	throw new Exception("An error has happened");
    }
    catch (Exception ex)
    {
    	System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
    
        Console.WriteLine(trace.GetFrame(0).GetMethod().ReflectedType.FullName);
        Console.WriteLine("Line: " + trace.GetFrame(0).GetFileLineNumber());
        Console.WriteLine("Column: " + trace.GetFrame(0).GetFileColumnNumber());
    }
