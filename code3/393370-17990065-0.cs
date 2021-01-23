    SqlException se = null;
    Exception next = ex;
    
    while (next.InnerException != null) 
    {
       se = next.InnerException as SqlException;
       next = next.InnerException;
    }
    if (se != null)
    {
        // Do your SqlException processing here
    }
    else
    {
        // Do other exception processing here
    }
