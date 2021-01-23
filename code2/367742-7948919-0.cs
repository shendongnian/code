    int result;
    try 
    {
        if (conn.State != ConnectionState.Open)
                        conn.Open();
                    
        result = Convert.ToInt32(dbComm.ExecuteNonQuery());
     }
     catch (Exception ex)
     {
        logger.Error(ex);
     }
     finally
     {
         if (conn.State != ConnectionState.Closed)
                        conn.Close();
     }
        
