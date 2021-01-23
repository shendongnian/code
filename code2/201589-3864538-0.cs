    try
    {
    //...
    }
    catch(Exception ex)
    {
    EventLog.WriteEntry(ex.Message + ex.StackTrace);
    }
