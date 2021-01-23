    private void Stop()
    {
        try
        {
             // Your code that does something to stop
        }
        finally
        {
             _stopped.Set();  // This signals the event
        }
    }
