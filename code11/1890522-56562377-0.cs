    try
    {
        cmd.CommandText = query;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    }
