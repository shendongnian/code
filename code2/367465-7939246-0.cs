    using(SqlConnection conn = new SqlConnection(Class1.CnnStr))
    {
      conn.Open();
      using(SqlCommand cmd = new SqlCommand("SELECT MAX(Code) FROM Customer",conn))
      {
        cmd.Connection.Open();  
        int max = Convert.ToInt32(cmd.ExecuteScalar().ToString());
      }
    }
   
