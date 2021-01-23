    OleDbConnection connection = new OleDbConnection(
        "Provider=VFPOLEDB.1;Data Source=.\\Northwind\\Northwind.dbc;"
    );
    connection.Open();
    DataTable tables = connection.GetSchema(
        System.Data.OleDb.OleDbMetaDataCollectionNames.Tables
    );
    foreach (System.Data.DataRow rowTables in tables.Rows)
    {
        Console.Out.WriteLine(rowTables["table_name"].ToString());
        DataTable columns = connection.GetSchema(
            System.Data.OleDb.OleDbMetaDataCollectionNames.Columns, 
            new String[] { null, null, rowTables["table_name"].ToString(), null }
        );
        foreach (System.Data.DataRow rowColumns in columns.Rows)
        {
            Console.Out.WriteLine(
                rowTables["table_name"].ToString() + "." +
                rowColumns["column_name"].ToString() + " = " +
                rowColumns["data_type"].ToString()
            );
        }
    }
