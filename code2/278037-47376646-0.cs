    public Task<IEnumerable<Foo>> LazyQueryAllFoos()
    {
       var sqlConn = new SqlConnection(_connectionString);
       using (var cmd = new SqlCommand(
            "SELECT Id, Col2, ... FROM LargeFoos", sqlConn))
       {
          await mySqlConn.OpenAsync();
          var reader = cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
          // Return the IEnumerable, without actually materializing Foos yet
          // Reader and Connection remain open until caller is done with the enumerable
          return LazyGenerateFoos(reader);
       }
    }
    
    // Helper method to manage lifespan of foos
    private static IEnumerable<Foo> GenerateFoos(IDataReader reader)
    {
        // Lifespan of the reader is scoped to the IEnumerable
        using(reader)
        {
           while (reader.Read())
           {
              yield return new Foo
              {
                  Id = Convert.ToInt32(reader["Id"]),
                  ...
              };
           }
        } // Reader is Closed + Disposed here => Connection also Closed.
    }
