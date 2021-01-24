    try 
    {
        ... 
    }
    // Don't do this!
    catch (Exception ex) // All the exceptions will be caught and...
    {
        // printed on the Console...
        // Which is invisible to you, since you develop Win Forms (WPF) application
        Console.WriteLine(ex.ToString());
        Console.Write(ex.StackTrace);
    }
