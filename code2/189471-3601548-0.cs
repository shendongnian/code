    public void Close()
    {
        if (s_LoggingEnabled)
        {
            Logging.Enter(Logging.Sockets, this, "Close", (string) null);
        }
        ((IDisposable)this).Dispose();
        if (s_LoggingEnabled)
        {
            Logging.Exit(Logging.Sockets, this, "Close", (string) null);
        }
    }
    
