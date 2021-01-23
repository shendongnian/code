    void Try(Action a, Action<Exception> onErr)
    {
        try
        {
            a();
        }
        catch (Exception e)
        {
            onErr(e);
        }
    }
