    private bool CheckUsername(string username)
    {
        string connString = "";
        string cmdText = "SELECT COUNT(*) FROM Users WHERE Username = @username";
        
        using(SqlConnection conn = new SqlConnection(connString))
        {
             conn.Open(); // Open DB connection.
             
             using(SqlCommand cmd = new SqlCommand(cmdText, conn))
             {
                 cmd.Parameters.AddWithValue("@username", username)); // Add the SQL parameter.
                 
                 int count = (int)cmd.ExecuteScalar();
                 // True (> 0) when the username exists, false (= 0) when the username does not exist.
                 return (count > 0);
             }
        }
    }
