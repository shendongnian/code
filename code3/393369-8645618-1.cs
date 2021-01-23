    catch(Exception ex)
    {
        Exception current = ex;
        SqlException se = null;
        do
        {
            se = current.InnerException as SqlException;
            current = current.InnerException;
        }
        while (current != null && se == null);
        if (se != null)
        {
            // Do your SqlException processing here
        }
        else
        {
            // Do other exception processing here
        }
    }
