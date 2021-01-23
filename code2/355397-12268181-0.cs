    using System.Data.OleDb;
    
    int numRecords = 2;
    int[] DISTRIBNO = new int[numRecords];
    DISTRIBNO[0] = 100;
    DISTRIBNO[1] = 101;
    
    string sql = "INSERT INTO Distributors (distribno) VALUES (:DISTRIBNO)";
    cnn = new Oracle.DataAccess.Client.OracleConnection(conString);
    cnn.Open();
    
    using (Oracle.DataAccess.Client.OracleCommand cmd = cnn.CreateCommand())
    {
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cmd.BindByName = true;
        // To use ArrayBinding, we need to set ArrayBindCount                
        cmd.ArrayBindCount = numRecords;
        cmd.CommandTimeout = 0;
    
        cmd.Parameters.Add(
                  ":DISTRIBNO", 
                  Oracle.DataAccess.Client.OracleDbType.Int32, 
                  BR_VOLMONTH,
                  ParameterDirection.Input);
    
        cmd.ExecuteNonQuery();
    }//using
