    try
    {
        // Normal workflow up here
    }
    catch (System.Exception ex)
    {
        if (ex.InnerException is InvalidOperationException) 
        { 
            // Handle InvalidOperationException
        }
        else 
        { 
            // Handle generic exception
        } 
        
        Console.WriteLine(ex.StackTrace);
    }
