    string query = "SELECT [Order ID], [Customer] FROM Orders";
    SqlCeConnection conn = new SqlCeConnection(connString);
    SqlCeCommand cmd = new SqlCeCommand(query, conn);
    
    conn.Open();
    SqlCeDataReader rdr = cmd.ExecuteReader();
    
    try
    {
        // Iterate through the results
        //
        while (rdr.Read())
        {
            int val1 = rdr.GetInt32(0);
            string val2 = rdr.GetString(1);
        }
    }
    finally
    {
        // Always call Close when done reading
        //
        rdr.Close();
    
        // Always call Close when done reading
        //
        conn.Close();
    }
