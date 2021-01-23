    OleDbConnection connection = new OleDbConnection(@"connection_string");
    connection.Open();
    DataTable schemaTable = connection.GetOleDbSchemaTable(
             OleDbSchemaGuid.Tables,
               new object[] { null, null, null, "VIEW" });
    foreach (DataRow row in schemaTable.Rows )
    {
        Console.WriteLine(row["TABLE_NAME"]);
    }
