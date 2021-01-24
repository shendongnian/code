    private void PopulateLists(List<IList> lists,
                               string select, 
                               string from, 
                               string order = "")
    {
      using ( SqlConnection conn = new SqlConnection(connectionString) )
      {
        conn.Open();
        if ( order == "" ) order = select;
        string strCommand = $"SELECT {select} FROM {from} ORDER BY {order}";
        using ( SqlCommand command = new SqlCommand(strCommand, conn) )
        {
          var dataReader = command.ExecuteReader();
          foreach ( var list in lists )
            list.Clear();
          while ( dataReader.Read() )
          {
            foreach ( var list in lists )
              list.Add(dataReader[select]);
          }
        }
      }
    }
