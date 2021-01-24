    private string getsomedetails(string Name, string applicationConnectionString)
    {
         string empty = string.Empty;
         string SQLStr = "SELECT xx FROM dbo.xxx WHERE Name = @xyz";
                
            
         using(SqlConnection connection = new SqlConnection(applicationConnectionString))
            {
              connection.Open();
              SqlCommand sqlCommand = new SqlCommand(SQLStr, connection);
              sqlCommand.Parameters.AddWithValue("@xyz", (object) Name);
              return sqlCommand.ExecuteScalar().ToString();
            }
    }
