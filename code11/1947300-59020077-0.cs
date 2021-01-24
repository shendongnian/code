    try
    {
        // Normal workflow up here
    }
    catch (System.InvalidOperationException ioex)
    {
        // Handle InvalidOperationException
        Console.WriteLine(ioex.StackTrace);
    }
    catch (System.Exception ex)
    {
        // Handle generic exception
        Console.WriteLine(ex.StackTrace);
    }
