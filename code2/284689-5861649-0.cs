    Object result;
    using (SqlConnection con = new SqlConnection(ConnectionString)) {
           con.Open();
           using (SqlCommand cmd = new SqlCommand(SQLStoredProcName, con)) {
           result = cmd.ExecuteScalar();
          }
    }
