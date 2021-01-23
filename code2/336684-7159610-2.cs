    using(var reader = command.ExecuteReader())
    {
      // This will return false - we don't care, we just want to make sure the schema table is there.
      reader.Read();
      var tableSchema = reader.GetSchemaTable();
      // Each row in the table schema describes a column
      foreach (DataRow row in tableSchema.Rows)
      {
        Console.WriteLine(row["ColumnName"]);
      }
    }
