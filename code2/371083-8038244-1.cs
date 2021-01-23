    string dbConn = "Data Source=localhost;Initial Catalog=Test;Integrated Security=SSPI;";
                string tableName = "TestTable";
                TableWatcher t = new TableWatcher(dbConn, tableName);
                t.RowsAdded += new EventHandler(t_RowsAdded);
                t.RowsDeleted += new EventHandler(t_RowsDeleted);
                t.Initialize();
                t.StartWatching(100);
