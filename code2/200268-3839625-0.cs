    IDbDataAdapter da;
    IDbCommand selectCommand = connection.CreateCommand();
    selectCommand.CommandType = CommandType.Text;
    selectCommand.CommandText = "SELECT field1, field2 FROM sourcetable";
    connection.Open();
    DataSet selectResults= new DataSet();
    da.Fill(selectResults); // get dataset
    selectCommand.Dispose();
    IDbCommand insertCommand;
    foreach(DataRow row in selectResults.Tables[0].Rows)
    {
        insertCommand = connection.CreateCommand();
        insertCommand.CommandType = CommandType.Text;
        insertCommand.CommandText = "INSERT INTO tablename (field1, field2) VALUES (3, '" + row["columnName"].ToString() + "'";   
    }
    insertCommand.Dispose();
    connection.Close();
