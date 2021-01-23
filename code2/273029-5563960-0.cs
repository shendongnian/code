    SqlConnection conn;
    try
    {
        //`using` scope operations are executed here
        conn = new SqlConnection(_dbconnstr));
        
    }
    catch
    {
        //exceptions are bubbled
        throw;
    }
    finally
    {
        //Dispose is always called
        conn.Dispose();
    }
