    try
    {
        SqlConnection conn = null; 
        conn = new SqlConnection(connString);  // connstring is your connection string to the database
        conn.Open(); 
    
        var strSQLCommand = "SELECT* FROM TABLE";  // statement is wrong! will raise an exception
        var command = new SqlCommand(strSQLCommand, conn); 
        var ret = command.ExecuteScalar(); 
     
        conn.Close(); 
        
        return ret; 
    }
    catch (SqlException e)
    {
        Console.WriteLine(e.Message);
    }
