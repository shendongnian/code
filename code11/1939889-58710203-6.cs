    private void PopulateItems(List<IList> listItems,
                               string clauseSelect,
                               string clauseFrom,
                               string clauseOrder = "")
    {
      using ( var connection = new SqlConnection(connectionString) )
      {
        connection.Open();
        if ( clauseOrder == "" )
          clauseOrder = clauseSelect;
        string sql = $"SELECT {clauseSelect} FROM {clauseFrom} ORDER BY {clauseOrder}";
        using ( var command = new SqlCommand(sql, connection) )
        {
          var reader = command.ExecuteReader();
          foreach ( var items in listItems )
            items.Clear();
          while ( reader.Read() )
            foreach ( var items in listItems )
              items.Add(reader[clauseSelect]);
        }
      }
    }
