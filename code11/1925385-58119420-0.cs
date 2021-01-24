    string connectionstring = //your connectionstring    
    
    using(SqlConnection conn = new SqlConnection(connectionstring))
    {
         conn.Open();
         SqlCommand cmd = new SqlCommand(/*Your query here between quotation marks*/, conn);
         int result = (int)cmd.ExecuteScalar();
         conn.Close();
    }
