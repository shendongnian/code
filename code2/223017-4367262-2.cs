    public void Send(SendOrPostCallback del)
    {
        // ...
        try
        {
            del();
        }
        catch (Exception ex)
        {
            // TODO: do something useful with the exception
        }
        
        // ...
    }
