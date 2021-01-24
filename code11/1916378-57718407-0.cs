    string query1 = "SELECT * FROM test1";
    string query2 = "SELECT * FROM test2";
    string query3 = "SELECT * FROM test3";
    DataSet dataSet = new DataSet();
    
    using(OleDbConnection connection = new OleDbConnection(connectionString)){
    
         connection.Open();
    
         OleDbCommand cmd = new OleDbCommand(q1, connection);
         OleDbDataAdapter da  = new OleDbDataAdapter(cmd);
         da.Fill(ds, "Test1");
         cmd.CommandText = q2;
         da  = new OleDbDataAdapter(cmd);
         da.Fill(ds, "Test2");
         cmd.CommandText = q3;
         da  = new OleDbDataAdapter(cmd);
         da.Fill(ds, "Test3");
    }
    Console.WriteLine("DataSet has {0} DataTables \n", ds.Tables.Count);
        foreach (DataTable objDt in ds.Tables)
                Console.WriteLine("{0}", objDt.TableName);
