    private void PopulateItems(List<IList> listItems,
                               string column,
                               string table,
                               string orderByColumn = "")
    {
      using ( var connection = new SqlConnection(connectionString) )
      {
        connection.Open();
        if ( orderByColumn == "" )
          orderByColumn = column;
        string sql = $"SELECT {column} FROM {table} ORDER BY {orderByColumn}";
        using ( var command = new SqlCommand(sql, connection) )
        {
          var reader = command.ExecuteReader();
          foreach ( var items in listItems )
            items.Clear();
          while ( reader.Read() )
            foreach ( var items in listItems )
              items.Add(reader[column]);
        }
      }
    }
