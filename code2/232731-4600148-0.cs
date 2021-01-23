    cmdSQLite = new SQLiteCommand("SELECT * FROM TableName", connectionSQLite);
       daSQLite = new SQLiteDataAdapter();
       daSQLite.SelectCommand = cmdSQLite;
       dsSQLite = new DataSet();               
       daSQLite.Fill(dsSQLite, "TableName");
       dsSQLite.Tables["TableName"].Rows[NumberOfRowToChange]["ColumnName"] = somevalue;
       //...
       daSQLite.Update(dsSQLite, "TableName");
