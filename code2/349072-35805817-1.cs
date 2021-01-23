    SqlConnection rConn = connectToSQL(); //returns sql connection
    SqlCommand SqlCmd = new SqlCommand();
    SqlCmd = rConn.CreateCommand();
    SqlCmd.CommandText = "SELECT ORDINAL_POSITION, " +
                             "COLUMN_NAME, " +
                             "DATA_TYPE, " +
                             "CHARACTER_MAXIMUM_LENGTH, " +
                             "IS_NULLABLE " +
                        "FROM INFORMATION_SCHEMA.COLUMNS " +
                        "WHERE TABLE_NAME = 'TableName'";
    SqlDataReader SqlDr = SqlCmd.ExecuteReader();
    SqlDr.Read();
    while (SqlDr.Read()) { 
        var OrdPos = SqlDr.GetValue(0);
        var ColName = SqlDr.GetValue(1);
        var DataType = SqlDr.GetValue(2);
        var CharMaxLen = SqlDr.GetValue(3);
        var IsNullable = SqlDr.GetValue(4);
        Console.WriteLine("ColName - " + ColName + " DataType - " + DataType + " CharMaxLen - " + CharMaxLen);
    }
