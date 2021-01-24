    void DoMyJob(Action job)
    {
        APIHelper.Login();
        try
        {
            job();
        }
        finally
        {
            APIHelper.Logout();
        }
    }
