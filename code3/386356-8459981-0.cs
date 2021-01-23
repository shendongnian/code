    string yourConnectionString = "......";
    List<int> allSSN = new List<int>();
    string sqlStmt = "SELECT SSN FROM dbo.Elects";
    using(SqlConnection conn = new SqlConnection(yourConnectionString) 
    using(SqlCommand cmd = new SqlCommand(sqlStmt, conn))
    {
        conn.Open();
        using(SqlDataReader rdr = cmd.ExecuteReader())
        {
            while(rdr.Read())
            {
               int ssn = rdr.GetInt32(0);
               allSSN.Add(ssn);
            }
 
            rdr.Close();
        }
        conn.Close();
    }
