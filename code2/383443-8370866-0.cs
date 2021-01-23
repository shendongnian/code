    using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLSERVER; Initial Catalog=BOSS; Integrated Security=TRUE")){
      conn.Open();  
      using (SqlCommand command = new SqlCommand(sqlString, conn)){
         //stuff...
         command.ExecuteNonQuery();
      }
    }
