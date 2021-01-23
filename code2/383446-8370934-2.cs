    using(SqlConnection sc = new SqlConnection("Data Source=.\\SQLSERVER; Initial Catalog=BOSS; Integrated Security=TRUE"))
    {
    
      using(SqlCommand command = new SqlCommand())
      {
        command.CommandText = "INSERT INTO contact (FirstName, LastName) VALUES(@FIRSTNAME , @LASTNAME"); 
        command.CommandType = CommandType.Text;
        command.Connection = sc;
        
        command.Parameters.AddWithValue("@FIRSTNAME", textBox2.Text); 
        command.Parameters.AddWithValue("@LASTNAME", textBox3.Text); 
        sc.Open();
        
        command.ExecuteNonQuery();
        
      }
    
    }
