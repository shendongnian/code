    private void ConnectToDBF()
    {            
        System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
        oConn.ConnectionString = @"Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=D:\databases\;Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
        oConn.Open();
        System.Data.Odbc.OdbcCommand oCmd = oConn.CreateCommand();
        // Insert the row
        oCmd.CommandText = @"INSERT INTO C:\rd\Setup\Test.DBF VALUES(999, 'RA-12')";
        oCmd.ExecuteNonQuery();
        // Read the table
        oCmd.CommandText = @"SELECT * FROM C:\rd\Setup\Test.DBF";
        DataTable dt = new DataTable();
        dt.Load(oCmd.ExecuteReader());
        oConn.Close();
        dataGridView1.DataSource = dt;
    }
