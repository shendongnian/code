    [WebMethod()]
    public UserRecord[] GetUserRecords() 
    { 
 
      List<UserRecod> userRecords = new List<UserRecord>();
 
        string connString = "SERVER=localhost" + ";" + 
            "DATABASE=testdatabase;" + 
            "UID=root;" + 
            "PASSWORD=password;"; 
 
        //introduce a connection with mySQL database 
        using(MySqlConnection cnMySQL = new MySqlConnection(connString))
        {
          //create your mySql command object 
          using(MySqlCommand cmdMySQL = cnMySQL.CreateCommand())
          { 
                //set the command text (query) of the mySQL command object 
                cmdMySQL.CommandText = "select * from testdata"; 
                cmdMySql.CommandType = CommandType.Text;
                cmdMySql.Connection = cnMySql;
  
                cnMySql.Open();
                //create your mySQL reader object 
                using(MySqlDataReader reader = cmdMySQL.ExecuteReader())
                {
            
                    while(reader.Read())
                    {
                        userRecords.Add(new UserRecord() { Id = reader.GetInt32(reader.GetOrdinal("id"), Name = reader.GetString(reader.GetOrdinal("name")}
                    }
        
                }
 
        }
 
      }
      
      return userRecords.ToArray();
      
    }
