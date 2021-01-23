    using(SQLiteConnection connection = new SQLiteConnection(_connectionString))
    { 
       ..
       using(SQLiteCommand command = new SQLiteCommand(query.ToString(), connection))
       {
          using(SQLiteDataReader  reader = dReader = command.ExecuteReader())
          {
              dTable.Load(dReader);
          }
       }
    }
