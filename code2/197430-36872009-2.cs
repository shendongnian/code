    public bool TableExists(string tableName)
    {
      var conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=NWIND.mdb";      
      using (var connection = new OleDbConnection(conStr))
      {
        connection.Open();
        var tables = connection.GetSchema("Tables");
        var tableExists = false;
        for (var i = 0; i < tables.Rows.Count; i++)
        {
          tableExists = String.Equals(tables.Rows[i][2].ToString(),
                               tableName,
                               StringComparison.CurrentCultureIgnoreCase);
          if (tableExists)
            break;
        }
        return tableExists;
      }
    }
