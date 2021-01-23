    OleDbConnection conn =
     new OleDbConnection(
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
        "C:\\phycoaide\\phycoaide.mdb;Persist Security Info=False;");
    
    // retrieving schema for a single table
    OleDbCommand cmd = new OleDbCommand("taxa", conn);
    cmd.CommandType = CommandType.TableDirect;
    conn.Open();
    OleDbDataReader reader =
     cmd.ExecuteReader(CommandBehavior.SchemaOnly);
    DataTable schemaTable = reader.GetSchemaTable();
    reader.Close();
    conn.Close();
