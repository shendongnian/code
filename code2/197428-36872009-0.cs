    public List<string> GetTableColumnNames(string tableName)
    {
      var conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=NWIND.mdb";
      using (var connection = new OleDbConnection(conStr))
      {
        connection.Open();
        var schemaTable = connection.GetOleDbSchemaTable(
          OleDbSchemaGuid.Columns,
          new Object[] { null, null, tableName });
        if (schemaTable == null)
          return null;
        var columnOrdinalForName = schemaTable.Columns["COLUMN_NAME"].Ordinal;
        return (from DataRow r in schemaTable.Rows select r.ItemArray[columnOrdinalForName].ToString()).ToList();
      }
    }
