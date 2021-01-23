    {
        _timer.Stop();
        try
        {
            // do stuff here
        }
        catch (whatever exceptions)
        {
            // notify of exception
        }
        finally
        {
            timer.Start();
        }
    }
