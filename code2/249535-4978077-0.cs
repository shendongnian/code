    try
    {
        // ...
    }
    catch (Exception e)
    {
        // If it’s any value other than 1, we’re not interested in the exception
        if (value != 1)
            throw;        // note: throw; *not* throw e;
        // Process the exception here
    }
