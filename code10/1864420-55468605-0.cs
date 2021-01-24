    public static List<(string clientNo, string account)> DbQueryToArray()
    {
       const string SqlCString = "connString";
    
       var valuesList = new List<(string clientNo, string account)>();
    
       using (var connection = new SqlConnection(SqlCString))
       {
          connection.Open();
    
          using (var command = new SqlCommand("Select CLIENTNO, ACCOUNT_Purpose from audit.ACCOUNTS_AUDIT", connection))
          {
             var reader = command.ExecuteReader();
    
             while (reader.Read())
                valuesList.Add(((string)reader[0],(string)reader[1]) );
          }
       }
       return valuesList;
    }
