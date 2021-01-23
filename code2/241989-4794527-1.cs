    SqlConnection conn = null
    try
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        conn.Open()
        
        // do something with the connection
    }
    catch(Exception ex)
    {
        //log error
    }
    finally
    {
        // clean up connection
        if(conn!=null)
        {
            //check if connetion is open, if it is close it / dispose        
        }
    
    }
