    try
    {
        // Some code
    }
    catch(Exception ex)
    {
        // Log error
        Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
        // Continue
    }
