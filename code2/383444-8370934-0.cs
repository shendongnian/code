    using(SqlConnection sc = new SqlConnection("Data Source=.\\SQLSERVER; Initial Catalog=BOSS; Integrated Security=TRUE"))
    {
    
      using(SqlCommand command = new SqlCommand())
      {
        SqlCommand.CommandText = "INSERT INTO contact (FIrstName, LastName) VALUES(@FIRSTNAME , @LASTNAME"); 
        SqlCommand.CommandType = CommandType.Text;
        SqlCommand.Connection = sc;
        
        sc.Open();
        
        command.ExecuteNonQuery();
        
      }
    
    }
