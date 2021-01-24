    SqlConnection con = new SqlConnection();
    try
    {
    }
    finally
    {
        con.Dispose(); // And this will also close the connection
    }
