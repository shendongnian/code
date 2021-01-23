    // define a flow control method that performs an action, with an optional retry
    public static void WithRetry( Action action, Action recovery )
    {
        try {
            action(); 
        }
        catch (Exception) {
            recovery();
            action();
        }
    }
    public void Send(string body)
    {
        WithRetry(() =>
        // action logic:
        {
           m_Outputfile.Write(body);
           m_Outputfile.Flush();
        },
        // retry logic:
        () =>
        {
           m_Outputfile = new StreamWriter(m_Filepath, true);
        });
    }
