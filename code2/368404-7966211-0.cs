    //Use only for test code
    private void CallAndIgnoreException(Action action)
    {
        try
        {
            action();
        }
        catch
        {
             //probably want to add some logging here
        }
    }
