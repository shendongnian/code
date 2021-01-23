    SqlConnection con =  null;
    SqlCommand cmd = null;
    
    try
    {
        con = new SqlConnection(ConnectionString);
        cmd = new SqlCommand("Command", con);
        con.Open();
        cmd.ExecuteNonQuery();
    }
    finally
    {
        if (null != cmd);
            cmd.Dispose();
        if (null != con)
            con.Dispose();
    }
