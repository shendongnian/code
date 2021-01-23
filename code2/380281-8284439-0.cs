    OleDbConnection conn2 = new OleDbConnection(connectionString);
    conn2.Open();
    string sqlFill = "SELECT tblCodons.codonsFullName FROM tblCodons";
    OleDbCommand fill = new OleDbCommand(sqlFill, conn2);
    
    OleDbDataReader dataReader = fill.ExecuteReader();
    
    int j = 0;
    
    while(dataReader.Read())
    {
        comboBox1.Items.Add(dataReader.GetString(j));
        j++;
    }
