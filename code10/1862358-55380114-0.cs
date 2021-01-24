    using (var Connection = new SqlCeConnection(ConnectionString)) {
      Connection.Open();
      string sql = 
         @"INSERT INTO Localitati(Nume) 
                VALUES (@Nume)";
    
      using (SqlCeCommand Command = new SqlCeCommand(sql, Connection)) {
        Command.Parameters.Add("@Nume", PutRdbmsTypeHere); //TODO: provide RDBMS type here
    
        foreach (var Line in Lines) {
          // Assign parameter(s)...
          Command.Parameters["@Nume"].Value = Line.Substring(0, Line.IndexOf(Spliter));
          // ... and execute query
          Command.ExecuteNonQuery();
        }   
      }
    }
