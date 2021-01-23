    SqlConnection conn;
    try
    {
        conn = new SqlConnection(_dbconnstr)
    }
    finally
    {
        conn.Dispose();
    }
