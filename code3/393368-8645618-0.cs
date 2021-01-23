    catch(Exception ex)
    {
        SqlException se = null;
        do
        {
            se = ex.InnerException as SqlException;
        }
        while (ex.InnerException != null && se == null);
        if (se != null)
        {
            // Do your SqlException processing here
        }
        else
        {
            // Do other exception processing here
        }
    }
