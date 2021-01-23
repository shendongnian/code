    string columnName = "myColumnName"
    
    ADOX.Catalog cat = new ADOX.CatalogClass();
    ADODB.Connection conn = new ADODB.Connection();
    conn.Open(ConnectionString, null, null, 0);
    cat.ActiveConnection = conn;
    ADOX.Table mhs = cat.Tables["myTableName"];
    
    columnDescription = mhs.Columns[columnName].Properties["Description"].Value.ToString();
    
    conn.Close();
