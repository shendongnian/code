    var s = File.Create(...);
    // (only) if the previous line succeeded, 
    // we gain the responsibility to close s, no matter what
    try
    {
       // do some I/O
    }
    finally
    {
       s.Dispose();
    }
