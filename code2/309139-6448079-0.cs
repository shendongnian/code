    try
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
           conn.Open();
           SqlCommand comm = new SqlCommand(conn);
           comm.CommandText = "Select Col1, Col2 From Table1";  
           
           SqlCommand comm1 = new SqlCommand(conn);
           comm.CommentText = "Select Col1, Col2 From Table2";
    
           //Execute First Command Code
    
           //Execute Second Command Code
    
        } //Connection will be closed and disposed
    }
    catch (Exception e)
    {
        //Handle e - Really want to handle specific types of exceptions, like SqlExceptions etc.
    }
