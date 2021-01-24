    private void PopulateItems(List<IList> listItems,
                               string select, 
                               string from, 
                               string order = "")
    {
      using ( SqlConnection conn = new SqlConnection(connectionString) )
      {
        conn.Open();
        if ( order == "" ) 
          order = select;
        string strCommand = $"SELECT {select} FROM {from} ORDER BY {order}";
        using ( var command = new SqlCommand(strCommand, conn) )
        {
          var dataReader = command.ExecuteReader();
          foreach ( var itels in listItems )
            items.Clear();
          while ( dataReader.Read() )
            foreach ( var items in listItems)
              items.Add(dataReader[select]);
        }
      }
    }
