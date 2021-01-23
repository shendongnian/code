    // Microsoft Access provider factory
    DbProviderFactory factory =
        DbProviderFactories.GetFactory("System.Data.OleDb");
    
    DataTable userTables = null;
    
    using (DbConnection connection =
                factory.CreateConnection())
    {
        // c:\test\test.mdb
        connection.ConnectionString = "Provider=Microsoft
            .Jet.OLEDB.4.0;Data Source=c:\\test\\test.mdb";
        
        // We only want user tables, not system tables
        string[] restrictions = new string[4];
        restrictions[3] = "Table";
        
        connection.Open();
        
        // Get list of user tables
        userTables =
            connection.GetSchema("Tables", restrictions);
    }
    
    // Add list of table names to listBox
    for (int i=0; i < userTables.Rows.Count; i++)
        listBox1.Items.Add(userTables.Rows[i][2].ToString())
